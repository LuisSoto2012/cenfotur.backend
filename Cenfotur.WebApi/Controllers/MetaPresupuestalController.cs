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
    [Route("api/metapresupuestal")]
    public class MetaPresupuestalController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public MetaPresupuestalController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }

        [HttpGet] //api/metapresupuestal
        public async Task<ActionResult<List<MetaPresupuestal_O_DTO>>> Get()
        {
            var MetaPresupuestal = await _Context.MetasPresupuestales.ToListAsync();
            return _Mapper.Map<List<MetaPresupuestal_O_DTO>>(MetaPresupuestal);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<MetaPresupuestal_O_DTO>> Get(int Id)
        {
            var Meta_Presupuestal = await _Context.MetasPresupuestales.FirstOrDefaultAsync(e => e.AnioId == Id);
            if (Meta_Presupuestal == null)
            {
                return BadRequest("No existe una Meta Presupuestal con ese Id");
            }
            return _Mapper.Map<MetaPresupuestal_O_DTO>(Meta_Presupuestal);
        }

        [HttpPost] // Creación de Meta_Presupuestal
        public async Task<ActionResult> Post(MetaPresupuestal_I_DTO _MetaPresupuestal_I_DTO)
        {
            var ExisteMetaPresupuestal = await _Context.MetasPresupuestales.AnyAsync(e => e.Nombre == _MetaPresupuestal_I_DTO.Nombre);
            if (ExisteMetaPresupuestal)
            {
                return BadRequest($"Ya existe una Meta Presupuestal registrada con ese Nombre: {_MetaPresupuestal_I_DTO.Nombre}");
            }

            var Meta_Presupuestal = _Mapper.Map<MetaPresupuestal>(_MetaPresupuestal_I_DTO);
            Meta_Presupuestal.FechaCreacion = DateTime.Now;

            _Context.Add(Meta_Presupuestal);
            await _Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] //api/metapresupuestal/1
        public async Task<ActionResult> Put(MetaPresupuestal_I_DTO _MetaPresupuestal_I_DTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            var Existe = await _Context.MetasPresupuestales.AnyAsync(e => e.AnioId == Id);
            if (Existe)
            {

                var MetaPresupuestal = _Mapper.Map<MetaPresupuestal>(_MetaPresupuestal_I_DTO);
                MetaPresupuestal.AnioId = Id;
                MetaPresupuestal.FechaModificacion = DateTime.Now;

                _Context.Update(MetaPresupuestal);
                await _Context.SaveChangesAsync();
                return NoContent();
            }

            return NotFound("El Id de la Meta Presupuestal no existe");
        }
    }
}
