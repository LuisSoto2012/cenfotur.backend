using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Models;
using Cenfotur.Entidad.ViewModels;
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

        [HttpGet("RegistroPostulacion/{idPerfilRelacionado:int}")]
        public async Task<IEnumerable<RegistroPostulacion_O_DTO>> RegistroPostulacion([FromRoute]int idPerfilRelacionado)
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
                .Where(c => c.Activo && c.Curso.PerfilRelacionadoId == idPerfilRelacionado)
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
                    var nuevoRegistro = new ParticipanteCapacitacion
                    {
                        ParticipanteId = dto.ParticipanteId,
                        CapacitacionId = dto.CapacitacionId,
                        Estado = dto.Estado,
                        FechaCreacion = DateTime.Now,
                        UsuarioCreacionId = dto.UsuarioId
                    };

                    _context.Add(nuevoRegistro);
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
    }
}