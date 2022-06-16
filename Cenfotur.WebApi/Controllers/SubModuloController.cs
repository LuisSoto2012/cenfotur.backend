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
    [Route("api/submodulos")]
    public class SubModuloController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public SubModuloController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }
        [HttpGet] //api/submodulos
        public async Task<ActionResult<List<SubModulo_O_DTO>>> Get()
        {
            var SubModulos = await _Context.SubModulos.ToListAsync();
            return _Mapper.Map<List<SubModulo_O_DTO>>(SubModulos);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<SubModulo_O_DTO>> Get(int Id)
        {
            var SubModulo = await _Context.SubModulos.FirstOrDefaultAsync(e => e.SubModuloId == Id);
            if (SubModulo == null)
            {
                return BadRequest("No existe un Sub Módulo con ese Id");
            }
            return _Mapper.Map<SubModulo_O_DTO>(SubModulo);
        }

        [HttpPost] // Creación
        public async Task<ActionResult> Post(SubModulo_I_DTO _SubModulo_I_DTO)
        {
            //var ExisteSubModuloNombre = await _Context.SubModulos.AnyAsync(sm => sm.Nombre == _SubModulo_I_DTO.Nombre);
            //if (ExisteSubModuloNombre)
            //{
            //    return BadRequest($"Ya existe un Sub Módulo registrado con ese nombre: {_SubModulo_I_DTO.Nombre}");
            //}
            var ExisteModuloId = await _Context.Modulos.AnyAsync(m => m.ModuloId == _SubModulo_I_DTO.ModuloId);
            if (!ExisteModuloId)
            {
                return BadRequest($"El Id: {_SubModulo_I_DTO.ModuloId} de Módulo no existe");
            }

            var SubModulos = _Mapper.Map<SubModulo>(_SubModulo_I_DTO);
            SubModulos.FechaCreacion = DateTime.Now;

            _Context.Add(SubModulos);
            await _Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] //api/empleado/1
        public async Task<ActionResult> Put(SubModulo_I_DTO _SubModulo_I_DTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            var Existe = await _Context.SubModulos.AnyAsync(sm => sm.SubModuloId == Id);
            if (Existe)
            {

                var SubModulos = _Mapper.Map<SubModulo>(_SubModulo_I_DTO);
                SubModulos.SubModuloId = Id;
                SubModulos.FechaModificacion = DateTime.Now;


                _Context.Update(SubModulos);
                await _Context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }
    }
}
