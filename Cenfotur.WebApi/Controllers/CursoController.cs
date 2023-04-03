using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Entidades.Cursos;
using Cenfotur.Entidad.Models;
using Cenfotur.Negocio.Negocios.Cursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cenfotur.WebApi.Controllers
{
    [ApiController]
    [Route("api/cursos")]
    public class CursoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CursoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet] // api/cursos
        public async Task<IEnumerable<Curso_O_DTO>> Get()
        {
            var cursosDb = await _context.Cursos.Include(c => c.PerfilRelacionado).Include(x => x.CursoPerfilRelacionado).OrderByDescending(c => c.FechaCreacion).ToListAsync();
            return cursosDb.Select(c => _mapper.Map<Curso_O_DTO>(c));
        }
        
        [HttpGet("estadistica_1")] // api/cursos
        public List<CursoEstadistica_1_E> Estadistica_1()
        {
            CursoEstadistica_1_N obj = new();
            return obj.CursoEstadistica_1();
        }
        
        [HttpPost] // Crea
        public async Task<ActionResult> Post(Curso_I_DTO cursoIDto)
        {
            var cursoDbNombre = await _context.Cursos.AnyAsync(c => c.Nombre == cursoIDto.Nombre);
            if (cursoDbNombre)
            {
                return BadRequest($"Ya existe un curso registrado con ese nombre: {cursoIDto.Nombre }");
            }
            
            var cursoDbCodigo = await _context.Cursos.AnyAsync(c => c.Codigo == cursoIDto.Codigo);
            if (cursoDbCodigo)
            {
                return BadRequest($"Ya existe un curso registrado con ese código: {cursoIDto.Codigo }");
            }

            try
            {
                var cursoNuevo = _mapper.Map<Curso>(cursoIDto);
                cursoNuevo.FechaCreacion = DateTime.Now;
                _context.Add(cursoNuevo);
                await _context.SaveChangesAsync();
                var perfiles = new List<CursoPerfilRelacionado>();
                foreach (var perfilId in cursoIDto.PerfilRelacionado)
                {
                    var cursoPerfilRelacionado = new CursoPerfilRelacionado { CursoId = cursoNuevo.CursoId, PerfilRelacionadoId = perfilId };
                    perfiles.Add(cursoPerfilRelacionado);
                }

                if (perfiles.Any())
                {
                    _context.AddRange(perfiles);
                    await _context.SaveChangesAsync();
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
        public async Task<ActionResult> Put(Curso_I_DTO cursoIDto, int Id)
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
                var existe = await _context.Cursos.Include(x => x.CursoPerfilRelacionado).AnyAsync(e => e.CursoId == Id);
                if (existe)
                {
                    var curso = _mapper.Map<Curso>(cursoIDto);
                    curso.CursoId = Id;
                    curso.FechaModificacion = DateTime.Now;
                    curso.UsuarioModificacionId = cursoIDto.UsuarioModificacionId;
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                    var cursoDb = await _context.Cursos.Include(x => x.CursoPerfilRelacionado).FirstOrDefaultAsync(e => e.CursoId == Id);
                    //Eliminar antiguos registros perfiles
                    if (cursoDb.CursoPerfilRelacionado.Any())
                    {
                        _context.RemoveRange(cursoDb.CursoPerfilRelacionado);
                    }
                    await _context.SaveChangesAsync();
                    
                    var perfiles = new List<CursoPerfilRelacionado>();
                    foreach (var perfilId in cursoIDto.PerfilRelacionado)
                    {
                        var cursoPerfilRelacionado = new CursoPerfilRelacionado { CursoId = curso.CursoId, PerfilRelacionadoId = perfilId };
                        perfiles.Add(cursoPerfilRelacionado);
                    }

                    if (perfiles.Any())
                    {
                        _context.AddRange(perfiles);
                        await _context.SaveChangesAsync();
                    }
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
                var cursoDb = await _context.Cursos.FirstOrDefaultAsync(e => e.CursoId == id);
                if (cursoDb != null)
                {
                    cursoDb.FechaModificacion = DateTime.Now;
                    cursoDb.UsuarioModificacionId = usuarioModificacionId;
                    cursoDb.Activo = false;
                    _context.Update(cursoDb);

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