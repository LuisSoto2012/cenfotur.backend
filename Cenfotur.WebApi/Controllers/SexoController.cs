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
    [Route("api/sexos")]
    public class SexoController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public SexoController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }

        [HttpGet] // api/Roles
        public async Task<ActionResult<List<Sexo_O_DTO>>> Get()
        {
            var Sexos = await _Context.Sexos.ToListAsync();
            return _Mapper.Map<List<Sexo_O_DTO>>(Sexos);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Sexo_O_DTO>> Get(int Id)
        {
            var Sexo = await _Context.Sexos.FirstOrDefaultAsync(e => e.SexoId == Id);
            if (Sexo == null)
            {
                return BadRequest("No existe un genero con ese Id");
            }
            return _Mapper.Map<Sexo_O_DTO>(Sexo);
        }

        [HttpPost] // Creación de Genero ------------- Crea
        public async Task<ActionResult> Post(Sexo_I_DTO _Sexo_I_DTO)
        {
            var ExisteGenero = await _Context.Sexos.AnyAsync(e => e.Nombre == _Sexo_I_DTO.Nombre);
            if (ExisteGenero)
            {
                return BadRequest($"Ya existe un genero registrado con ese Nombre: {_Sexo_I_DTO.Nombre}");
            }

            var Sexos = _Mapper.Map<Sexo>(_Sexo_I_DTO);
            Sexos.FechaCreacion = DateTime.Now;


            _Context.Add(Sexos);
            await _Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] //api/sexo/1 ------------- Actualiza
        public async Task<ActionResult> Put(Sexo_I_DTO _Sexo_I_DTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            var Existe = await _Context.Sexos.AnyAsync(e => e.SexoId == Id);
            if (Existe)
            {
                var Sexo = _Mapper.Map<Sexo>(_Sexo_I_DTO);
                Sexo.SexoId = Id;
                Sexo.FechaModificacion = DateTime.Now;

                _Context.Update(Sexo);
                await _Context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound("El Id del Rol seleccionado no existe");
        }
    }
}
