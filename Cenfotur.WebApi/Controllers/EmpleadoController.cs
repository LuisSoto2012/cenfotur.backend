using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Entidades.Empleados;
using Cenfotur.Entidad.Models;
using Cenfotur.Negocio.Negocios.Empleados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cenfotur.WebApi.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmpleadoController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet] //api/Empleados
        public async Task<ActionResult<List<Empleado_O_DTO>>> Get()
        {
            var Empleados = await _context.Empleados.Include(e => e.EmpleadoRol)
                .Include(e => e.PuestoLaboral).ToListAsync();
            return _mapper.Map<List<Empleado_O_DTO>>(Empleados);
        }
    
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Empleado_O_DTO>> Get(int Id)
        {
            var Empleado = await _context.Empleados.Include(e => e.EmpleadoRol)
                .Include(e => e.PuestoLaboral).FirstOrDefaultAsync(e => e.EmpleadoId == Id);
            //Empleado.FechaNacimientoCorta = Empleado.FechaNacimiento.ToString("yyyy-MM-dd");

            if (Empleado == null)
            {
                return BadRequest("No existe un empleado con ese Id");
            }
            return _mapper.Map<Empleado_O_DTO>(Empleado);
        }
        
        [HttpGet("estadistica_1")] // api/cursos
        public List<EmpleadoEstadistica_1_E> Estadistica_1()
        {
            EmpleadoEstadistica_1_N obj = new();
            return obj.EmpleadoEstadistica_1();
        }

        [HttpPost] // Crea
        public async Task<ActionResult> Post(Empleado_I_DTO _Empleado_I_DTO)
        {
            var ExisteEmpleadoMismoDniUsuario = await _context.Empleados.AnyAsync(e => e.NumDoc == _Empleado_I_DTO.NumDoc || e.Usuario == _Empleado_I_DTO.Usuario);
            if (ExisteEmpleadoMismoDniUsuario)
            {
                return BadRequest($"Ya existe un empleado registrado con ese DNI: {_Empleado_I_DTO.NumDoc } ó usuario: {_Empleado_I_DTO.Usuario}");
            }
            
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var Empleado = _mapper.Map<Empleado>(_Empleado_I_DTO);
                Empleado.FechaCreacion = DateTime.Now;
                _context.Add(Empleado);
                //Add Role
                var EmpleadoRol = new EmpleadoRol { EmpleadoId = Empleado.EmpleadoId, RolId = _Empleado_I_DTO.RolId };
                _context.Add(EmpleadoRol);
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

        [HttpPut("{Id:int}")] //api/empleado/1
        public async Task<ActionResult> Put(Empleado_I_DTO _Empleado_I_DTO, int Id)
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
                var Existe = await _context.Empleados.AnyAsync(e => e.EmpleadoId == Id);
                if (Existe)
                {
                    var Empleados = _mapper.Map<Empleado>(_Empleado_I_DTO);
                    Empleados.EmpleadoId = Id;
                    Empleados.FechaModificacion = DateTime.Now;

                    _context.Update(Empleados);
                
                    //Update existing Role
                    var empleadoConRol = await _context.EmpleadoRol.FirstOrDefaultAsync(x => x.EmpleadoId == Id);

                    if (empleadoConRol != null)
                    {
                        _context.EmpleadoRol.Remove(empleadoConRol);
                        _context.EmpleadoRol.Add(new EmpleadoRol {EmpleadoId = Id, RolId = _Empleado_I_DTO.RolId});
                    }
                    else
                    {
                        //Add new role
                        var newRole = new EmpleadoRol { RolId = _Empleado_I_DTO.RolId, EmpleadoId = Id };
                        _context.Add(newRole);
                    }
                
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


    }
}
