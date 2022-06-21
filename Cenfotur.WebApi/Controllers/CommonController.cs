using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/comunes")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommonController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("Departamentos")]
        public async Task<IEnumerable<Departamento_O_DTO>> GetDepartamentos()
        {
            var departamentosDb = await _context.Departamentos.OrderBy(x => x.Nombre).ToListAsync();

            return departamentosDb.Select(x => _mapper.Map<Departamento_O_DTO>(x));
        }
        
        [HttpGet("Provincias")]
        public async Task<IEnumerable<Provincia_O_DTO>> GetProvincias([FromQuery]string departamentoId)
        {
            var provinciasDb = await _context.Provincias.Include(x => x.Departamento)
                .Where(x => x.Departamento.DepartamentoId == departamentoId).OrderBy(x => x.Nombre).ToListAsync();

            return provinciasDb.Select(x => _mapper.Map<Provincia_O_DTO>(x));
        }
        
        [HttpGet("Distritos")]
        public async Task<IEnumerable<Distrito_O_DTO>> GetDistritos([FromQuery]string departamentoId, [FromQuery]string provinciaId)
        {
            var distritosDb = await _context.Distritos.Include(x => x.Departamento).Include(x => x.Provincia)
                .Where(x => x.Departamento.DepartamentoId == departamentoId && x.Provincia.ProvinciaId == provinciaId)
                .OrderBy(x => x.Nombre).ToListAsync();

            return distritosDb.Select(x => _mapper.Map<Distrito_O_DTO>(x));
        }

        [HttpGet("TipoCapacitaciones")]
        public async Task<IEnumerable<TipoCapacitacion_O_DTO>> GetTipoCapacitaciones()
        {
            var tipoCapacitacionDb = await _context.TipoCapacitaciones.Where(x => x.Activo).OrderBy(x => x.Nombre).ToListAsync();

            return tipoCapacitacionDb.Select(x => _mapper.Map<TipoCapacitacion_O_DTO>(x));
        }
        
        [HttpGet("Facilitadores")]
        public async Task<IEnumerable<Facilitador_O_DTO>> GetFacilitadores()
        {
            var facilitadoresDb = await _context.Empleados.Where(x => x.Activo && x.PuestoLaboralId == 3).OrderBy(x => x.Nombres).ToListAsync();

            return facilitadoresDb.Select(x => _mapper.Map<Facilitador_O_DTO>(x));
        }
        
        [HttpGet("Gestores")]
        public async Task<IEnumerable<Gestor_O_DTO>> GetGestores()
        {
            var gestoresDb = await _context.Empleados.Where(x => x.Activo && x.PuestoLaboralId == 2).OrderBy(x => x.Nombres).ToListAsync();

            return gestoresDb.Select(x => _mapper.Map<Gestor_O_DTO>(x));
        }
        
        [HttpGet("Cursos")]
        public async Task<IEnumerable<Curso_C_DTO>> GetCursos()
        {
            var cursosDb = await _context.Cursos.Where(x => x.Activo).OrderBy(x => x.Nombre).ToListAsync();

            return cursosDb.Select(x => _mapper.Map<Curso_C_DTO>(x));
        }
    }
}