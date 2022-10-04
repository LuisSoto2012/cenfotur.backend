using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Entidades.Capacitaciones;
using Cenfotur.Entidad.Models;
using Cenfotur.Entidad.ViewModels;
using Cenfotur.Negocio.Negocios.Capacitaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Barcode = NetBarcode.Barcode;
using Font = System.Drawing.Font;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using Type = System.Type;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/capacitaciones")]
    [ApiController]
    public class CapacitacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ArchivoSettings _archivoSettings;

        public CapacitacionController(ApplicationDbContext context, IMapper mapper, ILogger<CapacitacionController> logger, IOptions<ArchivoSettings> archivoSettings)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _archivoSettings = archivoSettings.Value ?? throw new ArgumentNullException(nameof(archivoSettings));
        }
        
        [HttpGet] // api/capacitaciones
        public async Task<IEnumerable<Capacitacion_O_DTO>> Get([FromQuery] Capacitacion_F_DTO filtro)
        {
            IEnumerable<Capacitacion_O_DTO> listaResult = new List<Capacitacion_O_DTO>();
            try
            {
                if (!filtro.Anio.HasValue)
                    return listaResult;
            
                var capacitacionDb = await _context.Capacitaciones
                    .Include(c => c.Ubigeo.Provincia)
                    .Include(c => c.Ubigeo.Departamento)
                    .Include(c => c.Facilitador)
                    .Include(c => c.Gestor)
                    .Include(c => c.Curso)
                    .ThenInclude(cu => cu.PerfilRelacionado)
                    .Include(c => c.TipoCapacitacion)
                    .Include(c => c.Documentaciones)
                    .Include(c => c.MaterialesAcademicos)
                    .Where(c => c.FechaCreacion.Value.Year == filtro.Anio && (!filtro.Activo.HasValue || (c.Activo == filtro.Activo)) 
                                                                          && (!filtro.TipoCapacitacionId.HasValue || (c.TipoCapacitacionId == filtro.TipoCapacitacionId)))
                    .OrderByDescending(c => c.FechaCreacion).ToListAsync();
                
                listaResult = capacitacionDb.Select(c => _mapper.Map<Capacitacion_O_DTO>(c));;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(e.ToString());
            }

            return listaResult;
        }
        
        [HttpGet("estadistica_1")] // api/cursos
        public List<CapacitacionEstadistica_1_E> Estadistica_1(string Anio)
        {
            CapacitacionEstadistica_1_N obj = new();
            return obj.CapacitacionEstadistica_1(Anio);
        }
        
        [HttpPost] // Crea
        public async Task<ActionResult> Post(Capacitacion_I_DTO capacitacionIDto)
        {
            try
            {
                var capacitacionNueva = _mapper.Map<Capacitacion>(capacitacionIDto);
                capacitacionNueva.FechaCreacion = DateTime.Now;
                _context.Add(capacitacionNueva);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return Ok();
        }
        
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(Capacitacion_I_DTO capacitacionIDto, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();
            
            try
            {
                var capacitacionDb = await _context.Capacitaciones
                    .Include(x => x.Curso)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.Notas)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.CapacitacionId == Id);
                if (capacitacionDb != null)
                {
                    if (capacitacionDb.EstaCerrada)
                        return BadRequest("No se puede hacer modificaciones a una capacitación cerrada.");
                    if (!capacitacionDb.ParticipanteCapacitacion.Any())
                        return BadRequest("No se puede cerrar una capacitación que no tiene participantes.");
                    var capacitacion = _mapper.Map<Capacitacion>(capacitacionIDto);
                    capacitacion.CapacitacionId = Id;
                    capacitacion.FechaModificacion = DateTime.Now;
                    capacitacion.UsuarioModificacionId = capacitacionIDto.UsuarioModificacionId;
                    
                    //Cerrar capacitacion
                    if (capacitacionIDto.EstaCerrada)
                    {
                        capacitacion.EstaCerrada = true;
                        //Obtener participantes
                        var participantesDb = capacitacionDb.ParticipanteCapacitacion.Select(pc => pc.Participante);
                            var participantesAprobados = participantesDb.SelectMany(p => p.Notas.Where(n => int.Parse(n.Nf) >= 14));
                        //Generar certificados
                        IList<Certificado> listaCertificados = new List<Certificado>();
                        
                        foreach (var participante in participantesAprobados)
                        {
                            var codigo =
                                $"{capacitacionDb.Curso.FechaCreacion.Value.Year}{participante.Participante.NumeroDocumento}{DateTime.Now.ToString("yyyyMMdd")}" +
                                $"{DateTime.Now.ToString("HHmmss")}";
                            var nombreCompleto =
                                $"{participante.Participante.Nombres} {participante.Participante.ApellidoPaterno} {participante.Participante.ApellidoMaterno}";
                            var nombreCurso = $"{capacitacionDb.Curso.Nombre}";
                            var fechaActual =
                                $"Barranco, {DateTime.Now.Day} de {MonthName(DateTime.Now.Month)} de {DateTime.Now.Year}";
                            
                            var nuevoCert = new Certificado
                            {
                                Codigo = codigo,
                                CapacitacionId = Id,
                                FechaCertificado = DateTime.Now,
                                ParticipanteId = participante.ParticipanteId,
                                FechaCreacion = DateTime.Now
                            };

                            //Generar archivo
                            var ruta = @$"{_archivoSettings.RutaCertificados}{participante.Participante.NumeroDocumento}\{participante.CapacitacionId}\";
                            if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                            var rutaCompleta = $"{ruta}{codigo}.jpg";
                            var rutaCompletaPdf = $"{ruta}{codigo}.pdf";
                            nuevoCert.Ruta = rutaCompleta;
                            
                            var plantilla = _archivoSettings.CertificadoPlantilla;
                            
                            var barcode = new Barcode(codigo, NetBarcode.Type.Code11, false, 670, 55);
                            string barcodeImgPath = $"{ruta}{codigo}_barcode.jpg";
                            barcode.SaveImageFile(barcodeImgPath);
                            System.Drawing.Image barcodeImg = System.Drawing.Image.FromFile(barcodeImgPath);

                            PointF nombreLocation = new PointF(660f, 796f);
                            PointF cursoLocation = new PointF(608f, 1070f);
                            PointF fechaLocation = new PointF(922f, 1277f);
                            PointF codigoLocation = new PointF(245f, 1625f);
                            PointF barcodeLocation = new PointF(300f, 1590f);
                            
                            // PointF secondLocation = participante.UserType.Contains("MEDICO") || participante.UserType.Contains("MÉDICO") ? 
                            //     new PointF(128f, 830f) : new PointF(110f, 830f) ;
                            Bitmap bitmap = (Bitmap)System.Drawing.Image.FromFile(plantilla);//load the image file

                            using (Graphics graphics = Graphics.FromImage(bitmap))
                            {
                                using (var sf = new StringFormat()
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center,
                                })
                                using (Font textFont = new Font("Arial Black", 27))
                                {
                                    graphics.DrawString(nombreCompleto, textFont, Brushes.Black, nombreLocation, sf);
                                    // graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
                                }
                                using (var sf2 = new StringFormat()
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center,
                                })
                                using (Font textFont2 = new Font("Arial", 18, FontStyle.Bold))
                                {
                                    graphics.DrawString(nombreCurso, textFont2, Brushes.Black, cursoLocation, sf2);
                                }
                                using (var sf3 = new StringFormat()
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center,
                                })
                                using (Font textFont2 = new Font("Arial", 12))
                                {
                                    graphics.DrawString(fechaActual, textFont2, Brushes.Black, fechaLocation, sf3);
                                }
                                // Create rectangle for source image.
                                RectangleF srcRect = new RectangleF(50F, 50F, 1242F, 1242F);
                                GraphicsUnit units = GraphicsUnit.Pixel;
                                graphics.DrawImage(barcodeImg, barcodeLocation);
                                using (var sf4 = new StringFormat()
                                {
                                    Alignment = StringAlignment.Center,
                                    LineAlignment = StringAlignment.Center,
                                })
                                using (Font textFont2 = new Font("Arial", 8, FontStyle.Bold))
                                {
                                    graphics.DrawString($"Certificado Num: {codigo}", textFont2, Brushes.Black, codigoLocation, sf4);
                                }
                            }
                            using (MemoryStream memory = new MemoryStream())
                            {
                                using (FileStream fs = new FileStream(rutaCompleta, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    bitmap.Save(memory, ImageFormat.Jpeg);//save the image file
                                    byte[] bytes = memory.ToArray();
                                    fs.Write(bytes, 0, bytes.Length);
                                }
                            }
                            Document document = new Document();
                            using (var stream = new FileStream(rutaCompletaPdf, FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                PdfWriter.GetInstance(document, stream);
                                document.Open();
                                using (var imageStream = new FileStream(rutaCompleta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                                {
                                    var image =  iTextSharp.text.Image.GetInstance(imageStream);
                                    document.Add(image);
                                }
                                document.Close();
                            }
                            
                            listaCertificados.Add(nuevoCert);
                        }

                        if (listaCertificados.Any())
                        {
                            _context.AddRange(listaCertificados);
                        }
                    }
                    
                    _context.Update(capacitacion);
                    
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPut("cambiarEstado/{Id:int}")]
        public async Task<ActionResult> CambiarEstado(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            try
            {
                var Existe = await _context.Capacitaciones.AnyAsync(e => e.CapacitacionId == Id);
                if (Existe)
                {
                    var capacitacion = await _context.Capacitaciones.FirstOrDefaultAsync(x => x.CapacitacionId == Id);
                    if (capacitacion == null)
                    {
                        return NotFound("Capacitacion no existe");
                    }

                    capacitacion.Activo = !capacitacion.Activo;
                    _context.Update(capacitacion);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpDelete("{id:int}/{usuarioModificacionId:int}")]
        public async Task<ActionResult> Delete(int id, int usuarioModificacionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            try
            {
                var capacitacionDb = await _context.Capacitaciones.FirstOrDefaultAsync(e => e.CapacitacionId == id);
                if (capacitacionDb != null)
                {
                    capacitacionDb.FechaModificacion = DateTime.Now;
                    capacitacionDb.UsuarioModificacionId = usuarioModificacionId;
                    capacitacionDb.Activo = false;
                    _context.Update(capacitacionDb);

                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("validar-certificado/{codigo}")]
        public async Task<ActionResult<string>> ValidarCertificado([FromRoute] string codigo)
        {
            var certificadoDb = await _context.Certificados.FirstOrDefaultAsync(x => x.Codigo == codigo);

            if (certificadoDb == null)
                return NoContent();

            if (string.IsNullOrEmpty(certificadoDb.Ruta))
                return NoContent();

            return Convert.ToBase64String(System.IO.File.ReadAllBytes(certificadoDb.Ruta));
        }
        
        private string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
    }
}