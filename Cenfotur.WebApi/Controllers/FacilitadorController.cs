using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Models;
using Cenfotur.Entidad.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitadorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ArchivoSettings _archivoSettings;

        public FacilitadorController(ApplicationDbContext context, IMapper mapper, IOptions<ArchivoSettings> archivoSettings)
        {
            _context = context;
            _mapper = mapper;
            _archivoSettings = archivoSettings.Value ?? throw new ArgumentNullException(nameof(archivoSettings));
        }

        [HttpGet("obtener-capacitacion/{facilitadorId:int}")]
        public async Task<int> ObtenerCapacitacionId([FromRoute] int facilitadorId)
        {
            var capacitacionDb =
                await _context.Capacitaciones.FirstOrDefaultAsync(x =>
                    x.FacilitadorId == facilitadorId);
            return capacitacionDb?.CapacitacionId ?? 0;
        }
        
        [HttpGet("listar-formatos/{facilitadorId:int}/{capacitacionId:int}")]
        public async Task<ActionResult<DocumentosFacilitador_O_DTO>> ListarFormatos([FromRoute]int facilitadorId, [FromRoute]int capacitacionId)
        {
            try
            {
                var docFacilitador = new DocumentosFacilitador_O_DTO();
                //Gestion de documentos
                var documentacionDb = await _context.Documentaciones
                    .Include(x => x.Capacitacion)
                    .FirstOrDefaultAsync(x =>
                        x.CapacitacionId == capacitacionId && x.Capacitacion.FacilitadorId == facilitadorId);
                if (documentacionDb != null)
                {
                    docFacilitador.Tdr = string.IsNullOrEmpty(documentacionDb.TdrFacilitador) || documentacionDb.TdrFacilitador == "null"
                        ? null
                        : Convert.ToBase64String(System.IO.File.ReadAllBytes(documentacionDb.TdrFacilitador));
                    docFacilitador.Os = string.IsNullOrEmpty(documentacionDb.OsFacilitador) || documentacionDb.OsFacilitador == "null"
                        ? null
                        : Convert.ToBase64String(System.IO.File.ReadAllBytes(documentacionDb.OsFacilitador));
                }

                //Gestion Materiales
                var materialesDb = await _context.MaterialesAcademicos
                    .Include(x => x.Capacitacion)
                    .FirstOrDefaultAsync(x =>
                        x.CapacitacionId == capacitacionId && x.Capacitacion.FacilitadorId == facilitadorId);
                if (materialesDb != null)
                {
                    docFacilitador.Silabus = string.IsNullOrEmpty(materialesDb.Sillabus) || materialesDb.Sillabus == "null"
                        ? null
                        : Convert.ToBase64String(System.IO.File.ReadAllBytes(materialesDb.Sillabus));
                    docFacilitador.Ppt = string.IsNullOrEmpty(materialesDb.Ppt) || materialesDb.Ppt == "null"
                        ? null
                        : Convert.ToBase64String(System.IO.File.ReadAllBytes(materialesDb.Ppt));
                    docFacilitador.Evaluaciones = string.IsNullOrEmpty(materialesDb.Evaluaciones) || materialesDb.Evaluaciones == "null"
                        ? null
                        : Convert.ToBase64String(System.IO.File.ReadAllBytes(materialesDb.Evaluaciones));
                    docFacilitador.FichaAsistencia = string.IsNullOrEmpty(materialesDb.FichaAsistencia) || materialesDb.FichaAsistencia == "null"
                        ? null
                        : Convert.ToBase64String(System.IO.File.ReadAllBytes(materialesDb.FichaAsistencia));
                    docFacilitador.FormatoInforme = string.IsNullOrEmpty(materialesDb.FacFormatoInforme) || materialesDb.FacFormatoInforme == "null"
                        ? null
                        : Convert.ToBase64String(System.IO.File.ReadAllBytes(materialesDb.FacFormatoInforme));
                    docFacilitador.Instructivo = string.IsNullOrEmpty(materialesDb.FacInstructivos) || materialesDb.FacInstructivos == "null"
                        ? null
                        : Convert.ToBase64String(System.IO.File.ReadAllBytes(materialesDb.FacInstructivos));
                }
                
                //Informe
                var facilitadorAchivo = await _context.FacilitadorArchivos.FirstOrDefaultAsync(x =>
                    x.FacilitadorId == facilitadorId && x.CapacitacionId == capacitacionId &&
                    x.TipoArchivo == "INFORME");

                if (facilitadorAchivo != null)
                {
                    docFacilitador.Informe = string.IsNullOrEmpty(facilitadorAchivo.Archivo) || facilitadorAchivo.Archivo == "null"
                        ? null
                        : Convert.ToBase64String(System.IO.File.ReadAllBytes(facilitadorAchivo.Archivo));
                }
                
                return Ok(docFacilitador);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("cargar-informe")]
        public async Task<ActionResult> CargarInforme([FromForm] FacilitadorInforme_I_DTO dto)
        {
            try
            {
                //Validaciones
                var facilitadorDb =
                    await _context.Empleados.FirstOrDefaultAsync(x => x.EmpleadoId == dto.FacilitadorId);
                
                if (facilitadorDb == null)
                    return NotFound("No existe facilitador con ese Id.");
                
                var capacitacionDb =
                    await _context.Capacitaciones.FirstOrDefaultAsync(x => x.CapacitacionId == dto.CapacitacionId);
                
                if (capacitacionDb == null)
                    return NotFound("No existe capacitación con ese Id.");

                var registroDb = new FacilitadorArchivo();
                registroDb.FacilitadorId = dto.FacilitadorId;
                registroDb.CapacitacionId = dto.CapacitacionId;
                
                //Carga de Informe
                var ruta = @$"{_archivoSettings.RutaFacilitadores}{facilitadorDb.NumDoc}\Informe\";
                if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                
                if (dto.Informe != null)
                {
                    var registroInforma = dto.Informe;
                    var fullPath = string.Concat(ruta, registroInforma.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await registroInforma.CopyToAsync(fileStream);
                        registroDb.Archivo = fullPath;
                        registroDb.TipoArchivo = "INFORME";
                        registroDb.FechaCreacion = DateTime.Now;
                        _context.Add(registroDb);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                }

                return NotFound("No se ha seleccionado un informe para cargar.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPost("cargar-imagenes")]
        [RequestSizeLimit(100_000_000)]
        public async Task<ActionResult> CargarImagenes([FromForm] FacilitadorImagenes_I_DTO dto)
        {
            try
            {
                //Validaciones
                var facilitadorDb =
                    await _context.Empleados.FirstOrDefaultAsync(x => x.EmpleadoId == dto.FacilitadorId);
                
                if (facilitadorDb == null)
                    return NotFound("No existe facilitador con ese Id.");
                
                var capacitacionDb =
                    await _context.Capacitaciones.FirstOrDefaultAsync(x => x.CapacitacionId == dto.CapacitacionId);
                
                if (capacitacionDb == null)
                    return NotFound("No existe capacitación con ese Id.");
                
                //Carga de Imagenes
                var listadoInsertDb = new List<FacilitadorArchivo>();
                
                var ruta = @$"{_archivoSettings.RutaFacilitadores}{facilitadorDb.NumDoc}\Imagenes\";
                if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);

                if (dto.Imagenes.Count > 0)
                {
                    var registroDb = new FacilitadorArchivo();
                    registroDb.FacilitadorId = dto.FacilitadorId;
                    registroDb.CapacitacionId = dto.CapacitacionId;
                    
                    foreach (var imagen in dto.Imagenes)
                    {
                        var registroImagene = imagen;
                        var fullPath = string.Concat(ruta, registroImagene.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await registroImagene.CopyToAsync(fileStream);
                            registroDb.Archivo = fullPath;
                            registroDb.TipoArchivo = "IMAGEN";
                            registroDb.FechaCreacion = DateTime.Now;
                            listadoInsertDb.Add(registroDb);
                        }
                    }

                    if (listadoInsertDb.Count > 0)
                    {
                        _context.AddRange(listadoInsertDb);
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    
                }

                return NotFound("No se han seleccionado imágenes para cargar.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("ActualizarAsistencia")]
        public async Task<ActionResult> ActualizarAsistencia([FromBody] Asistencia_I_DTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                foreach (var data in dto.ListaAsistencia)
                {
                    //Obtener listado de registros de asistencia por Participante y Capacitacion
                    var asistenciaParticipanteDb = await _context.Asistencia.Where(x =>
                        x.ParticipanteId == data.ParticipanteId &&
                        x.CapacitacionId == data.CapacitacionId).ToListAsync();
                    //Por cada registro -> Actualizar la asistencia
                    foreach (var fechaDto in data.Fechas)
                    {
                        //Obtener registro
                        var registroDb =
                            asistenciaParticipanteDb.FirstOrDefault(x => x.FechaAsistencia.Date == fechaDto.Fecha.Date);

                        if (registroDb != null)
                        {
                            registroDb.Asistio = fechaDto.Asistio;
                            registroDb.FechaModificacion = DateTime.Now;
                            registroDb.SupervisorId = dto.SupervisorId.HasValue ? dto.SupervisorId.Value : registroDb.SupervisorId;
                            registroDb.FacilitadorId = dto.FacilitadorId.HasValue ? dto.FacilitadorId.Value : registroDb.FacilitadorId;
                            registroDb.UsuarioModificacionId = dto.FacilitadorId.HasValue ? dto.FacilitadorId.Value : dto.SupervisorId.HasValue ? dto.SupervisorId.Value : (int?)null;
                            _context.Update(registroDb);
                        }
                    }
                }

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("ActualizarNotas")]
        public async Task<ActionResult> ActualizarNotas([FromBody] FacilitadorActualizarNotas_I_DTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var listaDto = dto.ParticipantesNotas;

                if (listaDto.Any())
                {
                    foreach (var notaDto in listaDto)
                    {
                        var registroDb = await _context.Notas.Include(n => n.Capacitacion.Curso).FirstOrDefaultAsync(x =>
                            x.ParticipanteId == notaDto.ParticipanteId && x.CapacitacionId == dto.CapacitacionId);
                        
                        if (registroDb != null)
                        {
                            registroDb.Ee = notaDto.Ee;
                            registroDb.Ep = notaDto.Ep;
                            registroDb.Ed = notaDto.Ed;
                            registroDb.Ef = notaDto.Ef;
                            registroDb.Nf = notaDto.Ef == "IPI" ? "IPI" : await CalcularNF(registroDb);
                            registroDb.SupervisorId = dto.SupervisorId.HasValue ? dto.SupervisorId.Value : registroDb.SupervisorId;
                            registroDb.FacilitadorId = dto.FacilitadorId.HasValue ? dto.FacilitadorId.Value : registroDb.FacilitadorId;
                            registroDb.UsuarioModificacionId = dto.FacilitadorId.HasValue ? dto.FacilitadorId.Value : dto.SupervisorId.HasValue ? dto.SupervisorId.Value : (int?)null;
                            registroDb.FechaModificacion = DateTime.Now;

                            _context.Update(registroDb);
                        }
                    }
                    
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                
                return NotFound("No se ha encontrado registro de Notas con dicho participante y capacitacioón");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
            
        }

        private async Task<string> CalcularNF(Nota notaDb)
        {
            var cursoDb = notaDb.Capacitacion.Curso;
            string nf;
            
            //Validar si es IPI

            //Calcular dias necesarios de asistencia
            var horasMin = cursoDb.HorasAprobar;
            var horasTotal = cursoDb.Horas;
            var totalDias = (notaDb.Capacitacion.FechaFin - notaDb.Capacitacion.FechaInicio).TotalDays;
            var totalHorasPorDia = (int)(horasTotal / totalDias);
            var totalAsistenciasNecesarias = (int) horasMin / totalHorasPorDia;  
            
            //Validar asistencia
            var asistenciaParticipante = await _context.Asistencia.Where(x =>
                x.ParticipanteId == notaDb.ParticipanteId && x.CapacitacionId == notaDb.CapacitacionId && x.Asistio).ToListAsync();

            if (asistenciaParticipante.Count() < totalAsistenciasNecesarias)
            {
                nf = "IPI";
            }
            else
            {
                //Calcular NF
                decimal promPracticas = decimal.Parse(string.IsNullOrEmpty(notaDb.Ep) ? "0" : notaDb.Ep);
                decimal promExFinal = decimal.Parse(string.IsNullOrEmpty(notaDb.Ef) ? "0" : notaDb.Ef);

                var porcentajePractias = cursoDb.Practica ?? 0 + cursoDb.Practica2 ??
                    0 + cursoDb.Practica3 ?? 0 + cursoDb.Practica4 ?? 0 + cursoDb.Practica5 ?? 0;
                var porcentajeFinal = 1 - porcentajePractias;

                nf = Math.Round((promPracticas * porcentajePractias) + (promExFinal * porcentajeFinal), 0).ToString(CultureInfo.InvariantCulture);
            }
            
            return nf;
        }
        
    }
}