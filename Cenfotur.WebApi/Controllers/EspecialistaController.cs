using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialistaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EspecialistaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("listar-directorio-encuesta")]
        public async Task<IEnumerable<DirectorioEncuesta_O_DTO>> GetDirectorioEncuesta()
        {
            var listarDB = await _context.DirectoriosEncuestas.Include(x => x.Distrito).ToListAsync();

            return listarDB.Select(x => _mapper.Map<DirectorioEncuesta_O_DTO>(x));
        }

        [HttpPost("registrar-directorio-encuesta")]
        public async Task<ActionResult> RegistrarDirectorioEncuesta([FromBody]DirectorioEncuesta_I_DTO dto)
        {
            try
            {
                var registroNuevo = _mapper.Map<DirectorioEncuesta>(dto);
                registroNuevo.FechaCreacion = DateTime.Now;
                registroNuevo.Activo = true;
                registroNuevo.UsuarioCreacionId = dto.UsuarioCreacionId.Value;
                _context.Add(registroNuevo);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return Ok();
        }
        
        [HttpPut("actualizar-directorio-encuesta/{Id:int}")]
        public async Task<ActionResult> ActualizarDirectorioEncuesta([FromBody]DirectorioEncuesta_I_DTO dto, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()))
            {
                return BadRequest("El Id es invalido");
            }

            try
            {
                var Existe = await _context.DirectoriosEncuestas.AnyAsync(e => e.DirectorioEncuestaId == Id);
                if (Existe)
                {
                    var registroDb = _mapper.Map<DirectorioEncuesta>(dto);
                    registroDb.Activo = true;
                    registroDb.DirectorioEncuestaId = Id;
                    registroDb.FechaModificacion = DateTime.Now;
                    registroDb.UsuarioModificacionId = dto.UsuarioModificacionId;
                    _context.Update(registroDb);

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
        
        [HttpDelete("eliminar-directorio-encuesta/{id:int}/{usuarioModificacionId:int}")]
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
                var registroDb = await _context.DirectoriosEncuestas.FirstOrDefaultAsync(e => e.DirectorioEncuestaId == id);
                if (registroDb != null)
                {
                    registroDb.FechaModificacion = DateTime.Now;
                    registroDb.UsuarioModificacionId = usuarioModificacionId;
                    registroDb.Activo = false;
                    _context.Update(registroDb);

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
        
        [HttpGet("listar-programaciones-info-pfc")]
        public async Task<IEnumerable<ProgramacionInfoPFC_O_DTO>> GetProgramacionesInfoPFC(int anio)
        {
            var listarDB = await _context.ProgramacionesInfoPFC
                .Include(x => x.Capacitacion.TipoCapacitacion)
                .Include(x => x.Capacitacion.Ubigeo.Departamento)
                .Include(x => x.Capacitacion.Ubigeo.Provincia)
                .Include(x => x.Capacitacion.Curso)
                .Include(x => x.Capacitacion.Gestor)
                .Include(x => x.Capacitacion.Facilitador)
                .Where(x => x.FechaCreacion.Value.Year == anio).ToListAsync();

            return listarDB.Select(x => _mapper.Map<ProgramacionInfoPFC_O_DTO>(x));
        }
        
        [HttpGet("listar-capacitaciones")]
        public async Task<IEnumerable<ProgramacionInfoPFC_O_DTO>> GetCapacitaciones(int anio)
        {
            var listarDB = await _context.Capacitaciones
                .Include(x => x.TipoCapacitacion)
                .Include(x => x.Ubigeo.Departamento)
                .Include(x => x.Ubigeo.Provincia)
                .Include(x => x.Curso)
                .Include(x => x.Gestor)
                .Include(x => x.Facilitador)
                .Where(x => x.FechaCreacion.Value.Year == anio).ToListAsync();

            return listarDB.Select(x => _mapper.Map<ProgramacionInfoPFC_O_DTO>(x));
        }
        
        [HttpPost("registrar-programaciones-info-pfc")]
        public async Task<ActionResult> RegistrarProgramacionInfoPFC([FromBody]ProgramacionInfoPFC_I_DTO dto)
        {
            try
            {
                var registroNuevo = _mapper.Map<ProgramacionInfoPFC>(dto);
                registroNuevo.FechaCreacion = DateTime.Now;
                registroNuevo.Activo = true;
                registroNuevo.UsuarioCreacionId = dto.UsuarioCreacionId.Value;
                _context.Add(registroNuevo);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return Ok();
        }
        
        [HttpPut("actualizar-programaciones-info-pfc/{Id:int}")]
        public async Task<ActionResult> ActualizarProgramacionInfoPFC([FromBody]ProgramacionInfoPFC_I_DTO dto, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()))
            {
                return BadRequest("El Id es invalido");
            }

            try
            {
                var Existe = await _context.ProgramacionesInfoPFC.AnyAsync(e => e.ProgramacionInfoPFCId == Id);
                if (Existe)
                {
                    var registroDb = _mapper.Map<ProgramacionInfoPFC>(dto);
                    registroDb.ProgramacionInfoPFCId = Id;
                    registroDb.FechaModificacion = DateTime.Now;
                    registroDb.UsuarioModificacionId = dto.UsuarioModificacionId;
                    _context.Update(registroDb);

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
        
        [HttpDelete("eliminar-programaciones-info-pfc/{id:int}/{usuarioModificacionId:int}")]
        public async Task<ActionResult> DeleteProgramacionInfoPFC(int id, int usuarioModificacionId)
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
                var registroDb = await _context.ProgramacionesInfoPFC.FirstOrDefaultAsync(e => e.ProgramacionInfoPFCId == id);
                if (registroDb != null)
                {
                    registroDb.FechaModificacion = DateTime.Now;
                    registroDb.UsuarioModificacionId = usuarioModificacionId;
                    registroDb.Activo = false;
                    _context.Update(registroDb);

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
    }
}