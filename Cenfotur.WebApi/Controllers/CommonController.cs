using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Models;
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
            var facilitadoresDb = await _context.Empleados.Include(x => x.EmpleadoRol).Where(x => x.Activo && x.EmpleadoRol.Select(er => er.RolId).Contains(7)).OrderBy(x => x.Nombres).ToListAsync();

            return facilitadoresDb.Select(x => _mapper.Map<Facilitador_O_DTO>(x));
        }
        
        [HttpGet("Gestores")]
        public async Task<IEnumerable<Gestor_O_DTO>> GetGestores()
        {
            var gestoresDb = await _context.Empleados.Include(x => x.EmpleadoRol).Where(x => x.Activo && x.EmpleadoRol.Select(er => er.RolId).Contains(10)).OrderBy(x => x.Nombres).ToListAsync();

            return gestoresDb.Select(x => _mapper.Map<Gestor_O_DTO>(x));
        }
        
        [HttpGet("Cursos")]
        public async Task<IEnumerable<Curso_C_DTO>> GetCursos()
        {
            var cursosDb = await _context.Cursos.Include(x => x.PerfilRelacionado).Where(x => x.Activo).OrderBy(x => x.Nombre).ToListAsync();

            return cursosDb.Select(x => _mapper.Map<Curso_C_DTO>(x));
        }

        [HttpGet("PerfilesRelacionados")]
        public async Task<IEnumerable<PerfilRelacionado_C_DTO>> GetPerfilesRelacionados()
        {
            var perfilesDb = await _context.PerfilesRelacionados.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return perfilesDb.Select(x => _mapper.Map<PerfilRelacionado_C_DTO>(x));
        }
        
        [HttpGet("EstadosCiviles")]
        public async Task<IEnumerable<EstadoCivil_C_DTO>> GetEstadosCiviles()
        {
            var estadosDb = await _context.EstadosCiviles.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return estadosDb.Select(x => _mapper.Map<EstadoCivil_C_DTO>(x));
        }
        
        [HttpGet("NivelesEducativos")]
        public async Task<IEnumerable<NivelEducativo_C_DTO>> GetNivelesEducativos()
        {
            var nivelesDb = await _context.NivelesEducativos.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return nivelesDb.Select(x => _mapper.Map<NivelEducativo_C_DTO>(x));
        }
        
        [HttpGet("Alcances")]
        public async Task<IEnumerable<Alcance_C_DTO>> GetAlcances()
        {
            var alcancesDb = await _context.Alcances.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return alcancesDb.Select(x => _mapper.Map<Alcance_C_DTO>(x));
        }
        
        [HttpGet("Cargos")]
        public async Task<IEnumerable<Cargo_C_DTO>> GetCargos([FromQuery]string tipoCargo)
        {
            var cargosDb = await _context.Cargos.Where(x => x.TipoCargo == tipoCargo && x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return cargosDb.Select(x => _mapper.Map<Cargo_C_DTO>(x));
        }
        
        [HttpGet("TiposRemuneraciones")]
        public async Task<IEnumerable<TipoRemuneracion_C_DTO>> GetTiposRemuneraciones()
        {
            var remuneracionesDb = await _context.TiposRemuneraciones.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return remuneracionesDb.Select(x => _mapper.Map<TipoRemuneracion_C_DTO>(x));
        }
        
        [HttpGet("Clases")]
        public async Task<IEnumerable<Clase_C_DTO>> GetClases()
        {
            var clasesDb = await _context.Clases.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return clasesDb.Select(x => _mapper.Map<Clase_C_DTO>(x));
        }
        
        [HttpGet("Categorias")]
        public async Task<IEnumerable<Categoria_C_DTO>> GetCategorias()
        {
            var categoriasDb = await _context.Categorias.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return categoriasDb.Select(x => _mapper.Map<Categoria_C_DTO>(x));
        }
        
        [HttpGet("Referencias")]
        public async Task<IEnumerable<Referencia_C_DTO>> GetReferencias()
        {
            var referenciasDb = await _context.Referencias.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return referenciasDb.Select(x => _mapper.Map<Referencia_C_DTO>(x));
        }
        
        [HttpGet("Rubros")]
        public async Task<IEnumerable<Rubro_C_DTO>> GetRubros()
        {
            var rubrosDb = await _context.Rubros.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return rubrosDb.Select(x => _mapper.Map<Rubro_C_DTO>(x));
        }
        
        [HttpGet("Dicerturs")]
        public async Task<IEnumerable<Dicertur_C_DTO>> GetDicerturs()
        {
            var dicertursDb = await _context.Dicerturs.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return dicertursDb.Select(x => _mapper.Map<Dicertur_C_DTO>(x));
        }
        
        [HttpGet("TiposContribuyente")]
        public async Task<IEnumerable<TipoContribuyente_C_DTO>> GetTiposContribuyente()
        {
            var tiposContribuyenteDb = await _context.TiposContribuyentes.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return tiposContribuyenteDb.Select(x => _mapper.Map<TipoContribuyente_C_DTO>(x));
        }
        
        [HttpGet("Programa")]
        public async Task<IEnumerable<Programa_C_DTO>> GetProgramas()
        {
            var programasDb = await _context.Programas.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return programasDb.Select(x => _mapper.Map<Programa_C_DTO>(x));
        }
        
        [HttpGet("TipoSupervision")]
        public async Task<IEnumerable<TipoSupervision_C_DTO>> GetTiposSupervision()
        {
            var tipoSupervisionDb = await _context.TiposSupervision.Where(x => x.Activo).OrderBy(x => x.Nombre)
                .ToListAsync();

            return tipoSupervisionDb.Select(x => _mapper.Map<TipoSupervision_C_DTO>(x));
        }

        [HttpGet("ObtenerDataSP1")]
        public async Task<IEnumerable<DataSP_O_DTO>> ObtenerDataSP1([FromQuery]string spNombre, [FromQuery]string param)
        {
            var result = await _context
                .Set<DataSP_O_DTO>()
                .FromSqlRaw($"exec [dbo].[{spNombre}] {param}").ToListAsync();

            return result;
        }
        
        [HttpGet("ObtenerDataSP2")]
        public async Task<IEnumerable<DataSP2_O_DTO>> ObtenerDataSP2([FromQuery]string spNombre, [FromQuery]string param)
        {
            var result = await _context
                .Set<DataSP2_O_DTO>()
                .FromSqlRaw($"exec [dbo].[{spNombre}] {param}").ToListAsync();

            return result;
        }
    }
}