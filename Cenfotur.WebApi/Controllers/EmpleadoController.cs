﻿using System;
using System.Collections.Generic;
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
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadoController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public EmpleadoController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }

        [HttpGet] //api/Empleados
        public async Task<ActionResult<List<Empleado_O_DTO>>> Get()
        {
            var Empleados = await _Context.Empleados.Include(e => e.EmpleadoRol).ToListAsync();
            return _Mapper.Map<List<Empleado_O_DTO>>(Empleados);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Empleado_O_DTO>> Get(int Id)
        {
            var Empleado = await _Context.Empleados.FirstOrDefaultAsync(e => e.EmpleadoId == Id);
            //Empleado.FechaNacimientoCorta = Empleado.FechaNacimiento.ToString("yyyy-MM-dd");

            if (Empleado == null)
            {
                return BadRequest("No existe un empleado con ese Id");
            }
            return _Mapper.Map<Empleado_O_DTO>(Empleado);
        }

        [HttpPost] // Crea
        public async Task<ActionResult> Post(Empleado_I_DTO _Empleado_I_DTO)
        {
            var ExisteEmpleadoMismoDniUsuario = await _Context.Empleados.AnyAsync(e => e.NumDoc == _Empleado_I_DTO.NumDoc || e.Usuario == _Empleado_I_DTO.Usuario);
            if (ExisteEmpleadoMismoDniUsuario)
            {
                return BadRequest($"Ya existe un empleado registrado con ese DNI: {_Empleado_I_DTO.NumDoc } ó usuario: {_Empleado_I_DTO.Usuario}");
            }
            
            await using var transaction = await _Context.Database.BeginTransactionAsync();

            try
            {
                var Empleado = _Mapper.Map<Empleado>(_Empleado_I_DTO);
                Empleado.FechaCreacion = DateTime.Now;
                _Context.Add(Empleado);
                //Add Role
                var EmpleadoRol = new EmpleadoRol { EmpleadoId = Empleado.EmpleadoId, RolId = _Empleado_I_DTO.RolId };
                _Context.Add(EmpleadoRol);
                await _Context.SaveChangesAsync();
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

            await using var transaction = await _Context.Database.BeginTransactionAsync();

            try
            {
                var Existe = await _Context.Empleados.AnyAsync(e => e.EmpleadoId == Id);
                if (Existe)
                {
                    var Empleados = _Mapper.Map<Empleado>(_Empleado_I_DTO);
                    Empleados.EmpleadoId = Id;
                    Empleados.FechaModificacion = DateTime.Now;

                    _Context.Update(Empleados);
                
                    //Update existing Role
                    var empleadoConRol = await _Context.EmpleadoRol.FirstOrDefaultAsync(x => x.EmpleadoId == Id);

                    if (empleadoConRol != null)
                    {
                        empleadoConRol.RolId = _Empleado_I_DTO.RolId;
                        _Context.EmpleadoRol.Update(empleadoConRol);
                    }
                    else
                    {
                        //Add new role
                        var newRole = new EmpleadoRol { RolId = _Empleado_I_DTO.RolId, EmpleadoId = Id };
                        _Context.Add(newRole);
                    }
                
                    await _Context.SaveChangesAsync();
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
