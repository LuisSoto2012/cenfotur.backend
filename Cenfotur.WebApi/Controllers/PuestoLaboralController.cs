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
    [Route("api/puestolaboral")]
    public class PuestoLaboralController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public PuestoLaboralController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }
        [HttpGet] //api/EmpleadoCargo
        public async Task<ActionResult<List<PuestoLaboral_O_DTO>>> Get()
        {
            var PuestosLaborales = await _Context.PuestosLaborales.ToListAsync();
            return _Mapper.Map<List<PuestoLaboral_O_DTO>>(PuestosLaborales);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<PuestoLaboral_O_DTO>> Get(int Id)
        {
            var PuestoLaboral = await _Context.PuestosLaborales.FirstOrDefaultAsync(e => e.PuestoLaboralId == Id);
            if (PuestoLaboral == null)
            {
                return BadRequest("No existe un Puesto Laboral con ese Id");
            }
            return _Mapper.Map<PuestoLaboral_O_DTO>(PuestoLaboral);
        }

        [HttpPost] // Creación de PuestoLaboral
        public async Task<ActionResult> Post(PuestoLaboral_I_DTO _PuestoLaboral_I_DTO)
        {
            var ExistePuestoLaboral = await _Context.PuestosLaborales.AnyAsync(e => e.Nombre == _PuestoLaboral_I_DTO.Nombre);
            if (ExistePuestoLaboral)
            {
                return BadRequest($"Ya existe un puesto registrado con ese Nombre: {_PuestoLaboral_I_DTO.Nombre}");
            }

            var PuestoLaboral = _Mapper.Map<PuestoLaboral>(_PuestoLaboral_I_DTO);
            PuestoLaboral.FechaCreacion = DateTime.Now;


            _Context.Add(PuestoLaboral);
            await _Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] //api/PuestoLaboral/1
        public async Task<ActionResult> Put(PuestoLaboral_I_DTO _PuestoLaboral_I_DTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            var Existe = await _Context.PuestosLaborales.AnyAsync(e => e.PuestoLaboralId == Id);
            if (Existe)
            {
                var PuestoLaboral = _Mapper.Map<PuestoLaboral>(_PuestoLaboral_I_DTO);
                PuestoLaboral.PuestoLaboralId = Id;
                PuestoLaboral.FechaModificacion = DateTime.Now;

                _Context.Update(PuestoLaboral);
                await _Context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound("El Id del puesto laboral seleccionado no existe");
        }



    }
}
