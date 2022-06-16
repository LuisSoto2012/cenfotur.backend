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
    [Route("api/RolSubModulo")]
    public class RolSubModuloController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public RolSubModuloController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }


        [HttpGet] //api/RolSubModulo
        public async Task<ActionResult<List<RolSubModulo_O_DTO>>> Get()
        {
            var RolSubModulos = await _Context.RolSubModulo.ToListAsync();
            return _Mapper.Map<List<RolSubModulo_O_DTO>>(RolSubModulos);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<RolSubModulo_O_DTO>> Get(int Id)
        {
            var RolSubModulo = await _Context.RolSubModulo.FirstOrDefaultAsync(e => e.RolSubModuloId == Id);
            if (RolSubModulo == null)
            {
                return BadRequest("No existe un RolSubModulo con ese Id");
            }
            return _Mapper.Map<RolSubModulo_O_DTO>(RolSubModulo);
        }

        [HttpPost] // Creación de RolSubmodulo
        public async Task<ActionResult> Post(RolSubModulo_I_DTO _RolSubModulo_I_DTO)
        {
            var ExisteRolSubModulo = await _Context.RolSubModulo.AnyAsync(e => e.RolId == _RolSubModulo_I_DTO.RolId && e.SubModuloId == _RolSubModulo_I_DTO.SubModuloId);
            if (ExisteRolSubModulo)
            {
                return BadRequest($"Ya existe un registro igual con esos datos: {_RolSubModulo_I_DTO.RolId} y {_RolSubModulo_I_DTO.SubModuloId} ");
            }

            var RolSubModulo = _Mapper.Map<RolSubModulo>(_RolSubModulo_I_DTO);
            RolSubModulo.FechaCreacion = DateTime.Now;


            _Context.Add(RolSubModulo);
            await _Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] //api/RolSubModulo/1
        public async Task<ActionResult> Put(RolSubModulo_I_DTO _RolSubModulo_I_DTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            var Existe = await _Context.RolSubModulo.AnyAsync(e => e.RolSubModuloId == Id);
            if (Existe)
            {
                var RolSubModulo = _Mapper.Map<RolSubModulo>(_RolSubModulo_I_DTO);
                RolSubModulo.RolSubModuloId = Id;
                RolSubModulo.FechaModificacion = DateTime.Now;

                _Context.Update(RolSubModulo);
                await _Context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound("El Id del RolSubModulo seleccionado no existe");
        }




    }
}
