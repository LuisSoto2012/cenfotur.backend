using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Entidades.Participantes;
using Cenfotur.Entidad.Models;
using Cenfotur.Entidad.ViewModels;
using Cenfotur.Negocio.Negocios.Participantes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ArchivoSettings _archivoSettings;

        public ParticipanteController(ApplicationDbContext context, IMapper mapper, IOptions<ArchivoSettings> archivoSettings)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _archivoSettings = archivoSettings.Value ?? throw new ArgumentNullException(nameof(archivoSettings));
        }
        
        [HttpGet("estadistica_1")] // api/cursos
        public List<ParticipanteEstadistica_1_E> Estadistica_1([FromQuery]int idCapacitacion)
        {
            ParticipanteEstadistica_1_N obj = new();
            return obj.ParticipanteEstadistica_1(idCapacitacion);
        }
        
        [HttpGet] // api/capacitaciones
        public async Task<IEnumerable<Participante_O_DTO>> Get()
        {
            var participantesDb = await _context.Participantes
                .Include(c => c.TipoDocumento)
                .Include(c => c.Departamento)
                .Include(c => c.PerfilRelacionado)
                .OrderByDescending(c => c.FechaCreacion).ToListAsync();
            return participantesDb.Select(c => _mapper.Map<Participante_O_DTO>(c));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Participante_O_DTO>> Get(int id)
        {
            var Participante = await _context.Participantes
                .Include(c => c.TipoDocumento)
                .Include(c => c.Departamento)
                .Include(c => c.Sexo)
                .Include(c => c.EstadoCivil)
                .Include(c => c.NivelEducativo)
                .Include(c => c.Alcance)
                .Include(c => c.CargoOperativo)
                .Include(c => c.CargoDirectivo)
                .Include(c => c.TipoRemuneracion)
                .Include(c => c.Distrito)
                .Include(c => c.Provincia)
                .Include(c => c.PerfilRelacionado).FirstOrDefaultAsync(x => x.ParticipanteId == id);

            if (Participante == null)
            {
                return BadRequest("No existe un empleado con ese Id");
            }
            return _mapper.Map<Participante_O_DTO>(Participante);
        }
        
        [HttpGet("ListadoPorCapacitacion/{idCapacitacion:int}")]
        public async Task<IEnumerable<Participante_O_DTO>> ListadoPorCapacitacion([FromRoute]int idCapacitacion)
        {
            var listaDb = await _context.Participantes
                .Include(c => c.TipoDocumento)
                .Include(c => c.Departamento)
                .Include(c => c.Sexo)
                .Include(c => c.EstadoCivil)
                .Include(c => c.NivelEducativo)
                .Include(c => c.Alcance)
                .Include(c => c.CargoOperativo)
                .Include(c => c.CargoDirectivo)
                .Include(c => c.TipoRemuneracion)
                .Include(c => c.Distrito)
                .Include(c => c.Provincia)
                .Include(c => c.PerfilRelacionado)
                .Include(c => c.ParticipanteCapacitacion)
                .Where(x => x.ParticipanteCapacitacion.Any(pc => pc.CapacitacionId == idCapacitacion))
                .ToListAsync();

            return listaDb.Select(c => _mapper.Map<Participante_O_DTO>(c));;
        }
        
        [HttpPost] // Crea
        public async Task<ActionResult> Post([FromForm]Participante_I_DTO participanteIDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await using var transaction = await _context.Database.BeginTransactionAsync();
            
            try
            {
                var participanteNuevo = _mapper.Map<Participante>(participanteIDto);
                participanteNuevo.FechaCreacion = DateTime.Now;

                // Carga de Archivo

                var ruta = @$"{_archivoSettings.RutaParticipantes}{participanteIDto.NumeroDocumento}\";
                if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                
                if (participanteIDto.CertificadoTrabajo != null)
                {
                    var certificadoTrabajo = participanteIDto.CertificadoTrabajo;
                    var fullPath = string.Concat(ruta, certificadoTrabajo.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await certificadoTrabajo.CopyToAsync(fileStream);
                        participanteNuevo.CertificadoTrabajo = fullPath;
                    }
                }
                
                if (participanteIDto.CertificadoEstudios != null)
                {
                    var certificadoEstudios = participanteIDto.CertificadoEstudios;
                    var fullPath = string.Concat(ruta, certificadoEstudios.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await certificadoEstudios.CopyToAsync(fileStream);
                        participanteNuevo.CertificadoEstudios = fullPath;
                    }
                }
                
                //Empresa
                if (!string.IsNullOrEmpty(participanteIDto.Ruc) && !string.IsNullOrEmpty(participanteIDto.RazonSocial))
                {
                    //Crear empresa
                    var empresaNueva = new Empresa
                    {
                        Ruc = participanteIDto.Ruc,
                        RazonSocial = participanteIDto.RazonSocial,
                        NombreComercial = participanteIDto.NombreComercial,
                        TelefonoFijo = participanteIDto.TelefonoFijo
                    };
                    _context.Add(empresaNueva);
                    await _context.SaveChangesAsync();
                    participanteNuevo.EmpresaId = empresaNueva.EmpresaId;
                }
                
                _context.Add(participanteNuevo);
                
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return Ok();
        }
        
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put([FromForm]Participante_I_DTO participanteIDto, int Id)
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
                var Existe = await _context.Participantes.AnyAsync(e => e.ParticipanteId == Id);
                if (Existe)
                {
                    var participante = _mapper.Map<Participante>(participanteIDto);
                    participante.ParticipanteId = Id;
                    participante.FechaModificacion = DateTime.Now;
                    participante.UsuarioModificacionId = participanteIDto.UsuarioModificacionId;
                    
                    // Carga de Archivo

                    var ruta = @$"{_archivoSettings.RutaParticipantes}{participanteIDto.NumeroDocumento}\";
                    if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                
                    if (participanteIDto.CertificadoTrabajo != null)
                    {
                        var certificadoTrabajo = participanteIDto.CertificadoTrabajo;
                        var fullPath = string.Concat(ruta, certificadoTrabajo.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await certificadoTrabajo.CopyToAsync(fileStream);
                            participante.CertificadoTrabajo = fullPath;
                        }
                    }
                    else
                    {
                        participante.CertificadoTrabajo = participanteIDto.RutaCertificadoTrabajo;
                    }
                
                    if (participanteIDto.CertificadoEstudios != null)
                    {
                        var certificadoEstudios = participanteIDto.CertificadoEstudios;
                        var fullPath = string.Concat(ruta, certificadoEstudios.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await certificadoEstudios.CopyToAsync(fileStream);
                            participante.CertificadoEstudios = fullPath;
                        }
                    }
                    else
                    {
                        participante.CertificadoEstudios = participanteIDto.RutaCertificadoEstudios;
                    }
                    
                    _context.Update(participante);

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
                var participanteDb = await _context.Participantes.FirstOrDefaultAsync(e => e.ParticipanteId == id);
                if (participanteDb != null)
                {
                    participanteDb.FechaModificacion = DateTime.Now;
                    participanteDb.UsuarioModificacionId = usuarioModificacionId;
                    participanteDb.Activo = false;
                    _context.Update(participanteDb);

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

        [HttpGet("RegistroPostulacion")]
        public async Task<IEnumerable<RegistroPostulacion_O_DTO>> RegistroPostulacion([FromQuery]int idPerfilRelacionado, [FromQuery]int idParticipante)
        {
            var capacitacionesDb = await _context.Capacitaciones
                .Include(c => c.Ubigeo.Provincia)
                .Include(c => c.Ubigeo.Departamento)
                .Include(c => c.Facilitador)
                .Include(c => c.Gestor)
                .Include(c => c.Curso)
                .ThenInclude(cu => cu.PerfilRelacionado)
                .Include(c => c.TipoCapacitacion)
                .Include(c => c.Documentaciones)
                .Include(c => c.MaterialesAcademicos)
                .Include(c => c.ParticipanteCapacitacion)
                .Where(c => c.Activo && c.Curso.PerfilRelacionadoId == idPerfilRelacionado && (!c.ParticipanteCapacitacion.Any() || c.ParticipanteCapacitacion.Any(p => p.ParticipanteId == idParticipante)))
                .ToListAsync();
            
            return capacitacionesDb.Select(c => _mapper.Map<RegistroPostulacion_O_DTO>(c));
        }

        [HttpPost("RegistroCapacitacion")]
        public async Task<ActionResult> RegistroCapacitacion([FromBody]RegistroCapacitacion_I_DTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //Buscar capacitacion
                if (dto.Estado == "P")
                {
                    var registroDb = await _context.ParticipanteCapacitacion.FirstOrDefaultAsync(x =>
                        x.ParticipanteId == dto.ParticipanteId
                        && x.CapacitacionId == dto.CapacitacionId);

                    if (registroDb != null)
                    {
                        registroDb.Estado = dto.Estado;
                        registroDb.UsuarioModificacionId = dto.UsuarioId;
                        registroDb.FechaModificacion = DateTime.Now;
                        _context.Update(registroDb);
                    }
                    else
                    {
                        var nuevoRegistro = new ParticipanteCapacitacion
                        {
                            ParticipanteId = dto.ParticipanteId,
                            CapacitacionId = dto.CapacitacionId,
                            Estado = dto.Estado,
                            FechaCreacion = DateTime.Now,
                            UsuarioCreacionId = dto.UsuarioId
                        };

                        _context.Add(nuevoRegistro);
                    }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var registroDb = await _context.ParticipanteCapacitacion.FirstOrDefaultAsync(x =>
                        x.ParticipanteId == dto.ParticipanteId
                        && x.CapacitacionId == dto.CapacitacionId);

                    if (registroDb != null)
                    {
                        registroDb.Estado = dto.Estado;
                        registroDb.UsuarioModificacionId = dto.UsuarioId;
                        registroDb.FechaModificacion = DateTime.Now;
                        _context.Update(registroDb);
                        await _context.SaveChangesAsync();
                        
                        //actualizar empresa
                        var participanteDb =
                            await _context.Participantes.FirstOrDefaultAsync(
                                x => x.ParticipanteId == dto.ParticipanteId);
                        if (participanteDb != null)
                        {
                            int? empresaId = participanteDb.EmpresaId;
                            if (empresaId.HasValue)
                            {
                                var empresaDb =
                                    await _context.Empresas.FirstOrDefaultAsync(x => x.EmpresaId == empresaId);
                                if (empresaDb != null)
                                {
                                    var capacitacionDb =
                                        await _context.Capacitaciones.Include(c => c.Curso).FirstOrDefaultAsync(x =>
                                            x.CapacitacionId == dto.CapacitacionId);
                                    if (capacitacionDb != null)
                                    {
                                        empresaDb.NombreCurso = capacitacionDb.Curso.Nombre;
                                        empresaDb.Horas = capacitacionDb.Curso.Horas;
                                        
                                        _context.Update(empresaDb);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                        }
                    }
                }

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("ListadoPorCapacitacionPostuladoAceptado")]
        public async Task<IEnumerable<ParticipantePostulado_O_DTO>> ListadoPorCapacitacionPostuladoAceptado([FromQuery]int idCapacitacion)
        {
            var listaDb = await _context.ParticipanteCapacitacion
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.TipoDocumento)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.Departamento)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.Sexo)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.EstadoCivil)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.NivelEducativo)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.Alcance)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.CargoOperativo)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.CargoDirectivo)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.TipoRemuneracion)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.Distrito)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.Provincia)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.PerfilRelacionado)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.ParticipanteCapacitacion)
                .Include(pc => pc.Participante)
                .ThenInclude(c => c.Empresa)
                .Where(x => x.CapacitacionId == idCapacitacion)
                .Select(x => x.Participante)
                .ToListAsync();

            return listaDb.Select(c => _mapper.Map<ParticipantePostulado_O_DTO>(c));;
        }

        [HttpGet("DatosEncuesta")]
        public async Task<ActionResult<EncuenstaDatos_O_DTO>> GetDatosEncuesta([FromQuery] int participanteId,
            [FromQuery] int capacitacionId)
        {
            //Validaciones
            var participanteDb =
                await _context.Participantes.Include(x => x.Distrito).FirstOrDefaultAsync(p => p.ParticipanteId == participanteId);
            if (participanteDb == null)
            {
                return BadRequest("No existe un participante con ese Id");
            }

            var capacitacionDb =
                await _context.Capacitaciones.Include(x => x.Facilitador).FirstOrDefaultAsync(p => p.CapacitacionId == capacitacionId);
            if (capacitacionDb == null)
            {
                return BadRequest("No existe una capacitación con ese Id");
            }
            
            try
            {
                var facilitador = string.Concat(capacitacionDb.Facilitador.ApellidoPaterno, " ", capacitacionDb.Facilitador.ApellidoMaterno, ", ", capacitacionDb.Facilitador.Nombres);
                var encuestaRegistrada = await _context.EncuestaSatisfaccion.AnyAsync(x =>
                    x.ParticipanteId == participanteId && x.CapacitacionId == capacitacionId);
                var datos = new EncuenstaDatos_O_DTO(participanteDb.Distrito.Nombre, facilitador.ToUpper(), encuestaRegistrada);

                return Ok(datos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("RegistroEncuesta")]
        public async Task<ActionResult> RegistroEncuesta([FromBody] RegistroEncuentra_I_DTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                //Validaciones
                var participanteDb =
                    await _context.Participantes.FirstOrDefaultAsync(p => p.ParticipanteId == dto.ParticipanteId);
                if (participanteDb == null)
                {
                    return BadRequest("No existe un participante con ese Id");
                }

                dto.DistritoId = participanteDb.DistritoId;

                var capacitacionDb =
                    await _context.Capacitaciones.FirstOrDefaultAsync(p => p.CapacitacionId == dto.CapacitacionId);
                if (capacitacionDb == null)
                {
                    return BadRequest("No existe una capacitación con ese Id");
                }

                dto.FacilitadorId = capacitacionDb.FacilitadorId;

                var encuentra = _mapper.Map<EncuestaSatisfaccion>(dto);

                _context.Add(encuentra);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("ObtenerCapacitacion/{participanteId:int}")]
        public async Task<int> ObtenerCapacitacionId([FromRoute] int participanteId)
        {
            var capacitacionDb =
                await _context.ParticipanteCapacitacion.FirstOrDefaultAsync(x =>
                    x.ParticipanteId == participanteId && x.Estado == "A");
            return capacitacionDb?.CapacitacionId ?? 0;
        }
        
        [HttpGet("Asistencia")]
        public async Task<ActionResult<IEnumerable<Asistencia_O_DTO>>> GetAsistencia([FromQuery] int capacitacionId,
            [FromQuery] int? participanteId)
        {
            //Validaciones
            
            var capacitacionDb =
                await _context.Capacitaciones.FirstOrDefaultAsync(p => p.CapacitacionId == capacitacionId);
            if (capacitacionDb == null)
            {
                return BadRequest("No existe una capacitación con ese Id");
            }

            if (participanteId.HasValue)
            {
                var participanteDb =
                    await _context.Participantes.FirstOrDefaultAsync(p => p.ParticipanteId == participanteId.Value);
                if (participanteDb == null)
                {
                    return BadRequest("No existe un participante con ese Id");
                }
            }

            var asistenciaDb = await _context.Asistencia.Include(a => a.Participante).Where(x =>
                x.CapacitacionId == capacitacionId &&
                (!participanteId.HasValue || x.ParticipanteId == participanteId.Value)).OrderBy(x => x.ParticipanteId).ThenBy(x => x.FechaAsistencia).ToListAsync();

            var listaAsistencia = new List<Asistencia_O_DTO>();

            var actualParticipanteId = 0;
            var dto = new Asistencia_O_DTO();
            dto.Fechas = new List<FechaAsistencia_O_DTO>();
            foreach (var data in asistenciaDb)
            {
                if (data.ParticipanteId != actualParticipanteId)
                {
                    if (actualParticipanteId != 0)
                    {
                        dto = new Asistencia_O_DTO();
                        dto.Fechas = new List<FechaAsistencia_O_DTO>();
                    }
                    dto.NumeroDocumento = data.Participante.NumeroDocumento;
                    dto.Participante = string.Concat(data.Participante.ApellidoPaterno, " ",
                        data.Participante.ApellidoMaterno, ", ", data.Participante.Nombres).ToUpper();
                    actualParticipanteId = data.ParticipanteId;
                }

                var fechaDto = new FechaAsistencia_O_DTO();
                fechaDto.Fecha = data.FechaAsistencia;
                fechaDto.Asistio = data.Asistio;
                dto.Fechas.Add(fechaDto);
            }

            return listaAsistencia.OrderBy(x => x.Participante).ToList();
        }
        
        [HttpGet("Notas")]
        public async Task<ActionResult<IEnumerable<Nota_O_DTO>>> GetNotas([FromQuery] int capacitacionId,
            [FromQuery] int? participanteId)
        {
            //Validaciones
            
            var capacitacionDb =
                await _context.Capacitaciones.FirstOrDefaultAsync(p => p.CapacitacionId == capacitacionId);
            if (capacitacionDb == null)
            {
                return BadRequest("No existe una capacitación con ese Id");
            }

            if (participanteId.HasValue)
            {
                var participanteDb =
                    await _context.Participantes.FirstOrDefaultAsync(p => p.ParticipanteId == participanteId.Value);
                if (participanteDb == null)
                {
                    return BadRequest("No existe un participante con ese Id");
                }
            }

            var notasDb = await _context.Notas.Include(a => a.Participante).Where(x =>
                x.CapacitacionId == capacitacionId &&
                (!participanteId.HasValue || x.ParticipanteId == participanteId.Value)).ToListAsync();

            var listaMap = notasDb.Select(x => _mapper.Map<Nota_O_DTO>(x)).OrderBy(x => x.Participante).ToList();

            return listaMap;
        }
    }
}