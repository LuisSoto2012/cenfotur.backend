using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Entidades.FichaSupervision;
using Cenfotur.Entidad.Models;
using Cenfotur.Negocio.Negocios.FichaSupervision;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public SupervisorController(ApplicationDbContext context, IMapper mapper, ILogger<SupervisorController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        
        [HttpGet("capacitaciones-activas")] // api/capacitaciones
        public async Task<IEnumerable<Capacitacion_O_DTO>> GetCapacitacionesActivas()
        {
            IEnumerable<Capacitacion_O_DTO> listaResult = new List<Capacitacion_O_DTO>();
            try
            {
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
                    .Where(c => c.Activo)
                    .OrderByDescending(c => c.Curso.Nombre).ToListAsync();
                
                listaResult = capacitacionDb.Select(c => _mapper.Map<Capacitacion_O_DTO>(c));;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(e.ToString());
            }

            return listaResult;
        }

        [HttpPost("registrar-ficha-supervision")]
        public async Task<ActionResult> RegistrarFichaSupervision([FromBody] FichaSupervision_I_DTO dto)
        {
            try
            {
                var fichaNueva = _mapper.Map<FichaSupervision>(dto);
                fichaNueva.FechaCreacion = DateTime.Now;
                _context.Add(fichaNueva);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPut("registrar-ficha-supervision/{Id:int}")]
        public async Task<ActionResult> Put(FichaSupervision_I_DTO dto, int Id)
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
                var Existe = await _context.FichasSupervision.AnyAsync(e => e.FichaSupervisionId == Id);
                if (Existe)
                {
                    var ficha = _mapper.Map<FichaSupervision>(dto);
                    ficha.FichaSupervisionId = Id;
                    ficha.FechaModificacion = DateTime.Now;
                    ficha.UsuarioModificacionId = dto.UsuarioModificacionId;
                    _context.Update(ficha);

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

        [HttpGet("listar-fichas-supervision")]
        public async Task<IEnumerable<FichaSupervision_O_DTO>> GetFichasSupervision([FromQuery] int anio)
        {
            var listaDb = await _context.FichasSupervision
                .Include(f => f.Capacitacion.Curso)
                .Include(f => f.Programa)
                .Include(f => f.Departamento)
                .Include(f => f.Supervisor)
                .Include(f => f.Facilitador)
                .Include(f => f.TipoSupervision)
                .Where(f => f.FechaSupervision.HasValue && f.FechaSupervision.Value.Year == anio)
                .OrderByDescending(f => f.FechaSupervision)
                .ToListAsync();

            return listaDb.Select(x => _mapper.Map<FichaSupervision_O_DTO>(x));

        }
        
        [HttpGet("estadistica_1")]
        public List<FichaSupervision_1_E> Estadistica_1(string Anio)
        {
            FichaSupervision_1_N obj = new();
            return obj.FichaSupervision_1(Anio);
        }
    }
}