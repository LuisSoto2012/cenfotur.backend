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
    public class EmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmpresaController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet] // api/capacitaciones
        public async Task<IEnumerable<Empresa_O_DTO>> Get()
        {
            var empresasDb = await _context.Empresas
                .Include(x => x.Rubro)
                .Include(x => x.Dicertur)
                .Include(x => x.Clase)
                .Include(x => x.Categoria)
                .Include(x => x.Departamento)
                .Include(x => x.Provincia)
                .Include(x => x.Distrito)
                .Include(x => x.TipoContribuyente)
                .OrderByDescending(x => x.FechaCreacion).ToListAsync();
            return empresasDb.Select(c => _mapper.Map<Empresa_O_DTO>(c));
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Empresa_O_DTO>> Get(int id)
        {
            var Empresa = await _context.Empresas
                .Include(x => x.Rubro)
                .Include(x => x.Dicertur)
                .Include(x => x.Clase)
                .Include(x => x.Categoria)
                .Include(x => x.Departamento)
                .Include(x => x.Provincia)
                .Include(x => x.Distrito)
                .Include(x => x.TipoContribuyente)
                .FirstOrDefaultAsync(x => x.EmpresaId == id);

            if (Empresa == null)
            {
                return BadRequest("No existe un empleado con ese Id");
            }
            return _mapper.Map<Empresa_O_DTO>(Empresa);
        }
        
        [HttpGet("ruc/{ruc}")]
        public async Task<ActionResult<Empresa_O_DTO>> Get(string ruc)
        {
            var Empresa = await _context.Empresas
                .Include(x => x.Rubro)
                .Include(x => x.Dicertur)
                .Include(x => x.Clase)
                .Include(x => x.Categoria)
                .Include(x => x.Departamento)
                .Include(x => x.Provincia)
                .Include(x => x.Distrito)
                .Include(x => x.TipoContribuyente)
                .FirstOrDefaultAsync(x => x.Ruc == ruc);

            if (Empresa == null)
            {
                return BadRequest("No existe un empleado con ese Ruc");
            }
            return _mapper.Map<Empresa_O_DTO>(Empresa);
        }
        
        [HttpPost] // Crea
        public async Task<ActionResult> Post([FromBody]Empresa_I_DTO empresaIDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var empresaNueva = _mapper.Map<Empresa>(empresaIDto);
                empresaNueva.FechaCreacion = DateTime.Now;

                _context.Add(empresaNueva);
                
                await _context.SaveChangesAsync();
                
                //Participante
                var participanteDb =
                    await _context.Participantes.FirstOrDefaultAsync(x => x.ParticipanteId == empresaIDto.ParticipanteId);
                if (participanteDb != null)
                {
                    //Crear relacion
                    participanteDb.EmpresaId = empresaNueva.EmpresaId;
                    _context.Update(participanteDb);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return NotFound($"Participante con Id {empresaIDto.ParticipanteId} no existe.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return Ok();
        }
        
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put([FromBody]Empresa_I_DTO empresaIDto, int Id)
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
                var Existe = await _context.Empresas.AnyAsync(e => e.EmpresaId == Id);
                if (Existe)
                {
                    var empresa = _mapper.Map<Empresa>(empresaIDto);
                    empresa.EmpresaId = Id;
                    empresa.FechaModificacion = DateTime.Now;
                    empresa.UsuarioModificacionId = empresaIDto.UsuarioModificacionId;

                    _context.Update(empresa);
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
                var empresaDb = await _context.Empresas.FirstOrDefaultAsync(e => e.EmpresaId == id);
                if (empresaDb != null)
                {
                    empresaDb.FechaModificacion = DateTime.Now;
                    empresaDb.UsuarioModificacionId = usuarioModificacionId;
                    empresaDb.Activo = false;
                    _context.Update(empresaDb);

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