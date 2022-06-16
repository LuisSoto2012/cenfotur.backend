using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cenfotur.WebApi.Controllers
{
    [ApiController]
    [Route("api/tipodocumento")]
    public class TipoDocumentoController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public TipoDocumentoController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }

        [HttpGet] //api/TipoDocumentos
        public async Task<ActionResult<List<TipoDocumento_O_DTO>>> Get()
        {
            var TipoDocumentos = await _Context.TipoDocumentos.ToListAsync();
            return _Mapper.Map<List<TipoDocumento_O_DTO>>(TipoDocumentos);
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<TipoDocumento_O_DTO>> Get(int Id)
        {
            var TipoDocumento = await _Context.TipoDocumentos.FirstOrDefaultAsync(e => e.TipoDocumentoId == Id);
            if (TipoDocumento == null)
            {
                return BadRequest("No existe un Tipo Documento con ese Id");
            }
            return _Mapper.Map<TipoDocumento_O_DTO>(TipoDocumento);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoDocumento_I_DTO _TipoDocumento_I_DTO)
        {
            var ExisteDocumentoConMismoNombre = await _Context.TipoDocumentos.AnyAsync(e => e.Nombre == _TipoDocumento_I_DTO.Nombre);
            if (ExisteDocumentoConMismoNombre)
            {
                return BadRequest($"Ya existe un modulo registrado con ese Nombre: {_TipoDocumento_I_DTO.Nombre}");
            }

            var TipoDocumento = _Mapper.Map<TipoDocumento>(_TipoDocumento_I_DTO);
            TipoDocumento.FechaCreacion = DateTime.Now;


            _Context.Add(TipoDocumento);
            await _Context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] //api/modulo/1
        public async Task<ActionResult> Put(TipoDocumento_I_DTO _TipoDocumento_I_DTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(Id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            var Existe = await _Context.TipoDocumentos.AnyAsync(e => e.TipoDocumentoId == Id);
            if (Existe)
            {
                var TipoDocumento = _Mapper.Map<TipoDocumento>(_TipoDocumento_I_DTO);
                TipoDocumento.TipoDocumentoId = Id;
                TipoDocumento.FechaModificacion = DateTime.Now;

                _Context.Update(TipoDocumento);
                await _Context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }


    }
}
