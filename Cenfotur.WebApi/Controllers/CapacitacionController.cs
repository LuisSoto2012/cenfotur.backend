using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Entidades.Capacitaciones;
using Cenfotur.Entidad.Models;
using Cenfotur.Negocio.Negocios.Capacitaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/capacitaciones")]
    [ApiController]
    public class CapacitacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CapacitacionController(ApplicationDbContext context, IMapper mapper, ILogger<CapacitacionController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
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

            try
            {
                var Existe = await _context.Capacitaciones.AnyAsync(e => e.CapacitacionId == Id);
                if (Existe)
                {
                    var capacitacion = _mapper.Map<Capacitacion>(capacitacionIDto);
                    capacitacion.CapacitacionId = Id;
                    capacitacion.FechaModificacion = DateTime.Now;
                    capacitacion.UsuarioModificacionId = capacitacionIDto.UsuarioModificacionId;
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
    }
}