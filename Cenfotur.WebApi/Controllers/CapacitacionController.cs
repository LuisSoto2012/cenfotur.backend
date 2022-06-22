using System;
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

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/capacitaciones")]
    [ApiController]
    public class CapacitacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CapacitacionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet] // api/capacitaciones
        public async Task<IEnumerable<Capacitacion_O_DTO>> Get([FromQuery] Capacitacion_F_DTO filtro)
        {
            var capacitacionDb = await _context.Capacitaciones
                .Include(c => c.Ubigeo.Provincia)
                .Include(c => c.Ubigeo.Departamento)
                .Include(c => c.Facilitador)
                .Include(c => c.Gestor)
                .Include(c => c.Curso)
                .Include(c => c.TipoCapacitacion)
                .Include(c => c.Documentaciones)
                .Where(c => c.FechaCreacion.Value.Year == filtro.Anio && c.Activo == filtro.Activo && c.TipoCapacitacionId == filtro.TipoCapacitacionId)
                .OrderByDescending(c => c.FechaCreacion).ToListAsync();
            return capacitacionDb.Select(c => _mapper.Map<Capacitacion_O_DTO>(c));
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