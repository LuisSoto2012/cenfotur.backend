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
    [Route("api/anios")]
    public class AnioController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public AnioController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }

        [HttpGet] //api/Roles
        public async Task<ActionResult<List<Anio_O_DTO>>> Get()
        {
            var Anios = await _Context.Anios.ToListAsync();
            return _Mapper.Map<List<Anio_O_DTO>>(Anios);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Anio_O_DTO>> Get(int Id)
        {
            var Anio = await _Context.Anios.FirstOrDefaultAsync(e => e.AnioId == Id);
            if (Anio == null)
            {
                return BadRequest("No existe un año con ese Id");
            }
            return _Mapper.Map<Anio_O_DTO>(Anio);
        }

        [HttpPost] // Creación de Anio
        public async Task<ActionResult> Post(Anio_I_DTO _Anio_I_DTO)
        {
            var ExisteAnio = await _Context.Anios.AnyAsync(e => e.Nombre == _Anio_I_DTO.Nombre);
            if (ExisteAnio)
            {
                return BadRequest($"Ya existe un Anio registrado con ese Nombre: {_Anio_I_DTO.Nombre}");
            }

            var Anios = _Mapper.Map<Anio>(_Anio_I_DTO);
            Anios.FechaCreacion = DateTime.Now;


            _Context.Add(Anios);
            await _Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] //api/anio/1
        public async Task<ActionResult> Put(Anio_I_DTO _Anio_I_DTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            var Existe = await _Context.Anios.AnyAsync(e => e.AnioId == Id);
            if (Existe)
            {
                var Anios = _Mapper.Map<Anio>(_Anio_I_DTO);
                Anios.AnioId = Id;
                Anios.FechaModificacion = DateTime.Now;

                _Context.Update(Anios);
                await _Context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound("El Id del Rol seleccionado no existe");
        }




    }
}
