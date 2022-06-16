using System;
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
    [Route("api/roles")]
    public class RolController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public RolController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }
        [HttpGet] //api/Roles
        public async Task<ActionResult<List<Rol_O_DTO>>> Get()
        {
            var Roles = await _Context.Roles.ToListAsync();
            return _Mapper.Map<List<Rol_O_DTO>>(Roles);
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Rol_O_DTO>> Get(int Id)
        {
            var Rol = await _Context.Roles.Include(rsm => rsm.RolSubModulo).FirstOrDefaultAsync(e => e.RolId == Id);
            if (Rol == null)
            {
                return BadRequest("No existe un rol con ese Id");
            }
            return _Mapper.Map<Rol_O_DTO>(Rol);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Rol_I_DTO _Rol_I_DTO)
        {
            var ExisteRolConMismoNombre = await _Context.Roles.AnyAsync(e => e.Nombre == _Rol_I_DTO.Nombre);
            if (ExisteRolConMismoNombre)
            {
                return BadRequest($"Ya existe un rol registrado con ese Nombre: {_Rol_I_DTO.Nombre}");
            }

            var Rol = _Mapper.Map<Rol>(_Rol_I_DTO);
            Rol.FechaCreacion = DateTime.Now;

            _Context.Add(Rol);
            await _Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] //api/rol/1
        public async Task<ActionResult> Put(Rol_I_DTO _Rol_I_DTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            var Existe = await _Context.Roles.AnyAsync(e => e.RolId == Id);
            if (Existe)
            {
                var Roles = _Mapper.Map<Rol>(_Rol_I_DTO);
                Roles.RolId = Id;
                Roles.FechaModificacion=DateTime.Now;

                _Context.Update(Roles);
                await _Context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound("El Id del Rol seleccionado no existe");
        }


    }
}
