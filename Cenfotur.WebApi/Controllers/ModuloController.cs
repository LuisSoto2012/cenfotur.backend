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
    [Route("api/modulos")]
    public class ModuloController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public ModuloController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }

        [HttpGet] //api/Modulos -------------------------------- Lista Todo --------------------------------
        public async Task<ActionResult<List<Modulo_1_O_DTO>>> Get()
        {
            //var Modulos = await _Context.Modulos.Include(sm => sm.SubModulos).ToListAsync();
            //return _Mapper.Map<List<Modulo_O_DTO>>(Modulos);

            var Modulos = await _Context.Modulos.Include(sm => sm.SubModulos).ToListAsync();
            return _Mapper.Map<List<Modulo_1_O_DTO>>(Modulos);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Modulo_1_O_DTO>> Get(int Id)
        {
            //var Modulo = await _Context.Modulos.Include(sm=>sm.SubModulos).FirstOrDefaultAsync(e => e.ModuloId == Id);
            //if (Modulo == null)
            //{
            //    return BadRequest("No existe un módulo con ese Id");
            //}
            //return _Mapper.Map<Modulo_O_DTO>(Modulo);

            var Modulo = await _Context.Modulos.Include(sm => sm.SubModulos).FirstOrDefaultAsync(e => e.ModuloId == Id);
            if (Modulo == null)
            {
                return BadRequest("No existe un módulo con ese Id");
            }
            return _Mapper.Map<Modulo_1_O_DTO>(Modulo);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Modulo_I_DTO _Modulo_I_DTO)
        {
            var ExisteModuloConMismoNombre = await _Context.Modulos.AnyAsync(e => e.Nombre == _Modulo_I_DTO.Nombre);
            if (ExisteModuloConMismoNombre)
            {
                return BadRequest($"Ya existe un modulo registrado con ese Nombre: {_Modulo_I_DTO.Nombre}");
            }

            var Modulo = _Mapper.Map<Modulo>(_Modulo_I_DTO);
            Modulo.FechaCreacion = DateTime.Now;


            _Context.Add(Modulo);
            await _Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] //api/modulo/1
        public async Task<ActionResult> Put(Modulo_I_DTO _Modulo_I_DTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            var Existe = await _Context.Modulos.AnyAsync(e => e.ModuloId == Id);
            if (Existe)
            {
                var Modulo = _Mapper.Map<Modulo>(_Modulo_I_DTO);
                Modulo.ModuloId = Id;
                Modulo.FechaModificacion = DateTime.Now;

                _Context.Update(Modulo);
                await _Context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
