using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificadoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ArchivoSettings _archivoSettings;
        private readonly ILogger _logger;

        public CertificadoController(ApplicationDbContext context, IMapper mapper, IOptions<ArchivoSettings> archivoSettings, ILogger<CertificadoController> logger)
        {
            _context = context;
            _mapper = mapper;
            _archivoSettings = archivoSettings.Value ?? throw new ArgumentNullException(nameof(archivoSettings));
            _logger = logger;
        }

        [HttpGet("listar-capacitaciones")]
        public async Task<IEnumerable<Capacitacion_O_DTO>> GetCapacitaciones([FromQuery] Capacitacion_F_DTO filtro)
        {
            IList<Capacitacion_O_DTO> listaResult = new List<Capacitacion_O_DTO>();
            try
            {
                if (!filtro.Anio.HasValue)
                    return listaResult;
            
                var capacitacionDb = await _context.Capacitaciones
                    .Include(c => c.Facilitador)
                    .Include(c => c.Gestor)
                    .Include(c => c.Curso)
                    .ThenInclude(cu => cu.PerfilRelacionado)
                    .Include(c => c.TipoCapacitacion)
                    .Include(c => c.Documentaciones)
                    .Include(c => c.MaterialesAcademicos)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.TipoDocumento)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.Departamento)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.Sexo)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.EstadoCivil)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.NivelEducativo)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.Alcance)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.CargoOperativo)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.CargoDirectivo)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.TipoRemuneracion)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.Provincia)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.Departamento)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.Distrito)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.PerfilRelacionado)
                    .Include(c => c.ParticipanteCapacitacion)
                    .ThenInclude(pc => pc.Participante.Certificados)
                    .Where(c => c.FechaCreacion.Value.Year == filtro.Anio && (!filtro.Activo.HasValue || (c.Activo == filtro.Activo)) 
                                                                          && (!filtro.TipoCapacitacionId.HasValue || (c.TipoCapacitacionId == filtro.TipoCapacitacionId)))
                    .OrderByDescending(c => c.FechaCreacion).ToListAsync();

                foreach (var capacitacion in capacitacionDb)
                {
                    var dto = _mapper.Map<Capacitacion_O_DTO>(capacitacion);
                    dto.Participantes = new List<Participante_O_DTO>();
                    var participantes = capacitacion.ParticipanteCapacitacion.Select(pc => pc.Participante);
                    foreach (var participante in participantes)
                    {
                        var participanteDto = _mapper.Map<Participante_O_DTO>(participante);
                        var certificadoCap =
                            participante.Certificados.FirstOrDefault(c =>
                                c.CapacitacionId == capacitacion.CapacitacionId);
                        participanteDto.Certificado = certificadoCap == null ? "" :
                            string.IsNullOrEmpty(certificadoCap.Ruta) || certificadoCap.Ruta == "null" ? "" :
                            Convert.ToBase64String(System.IO.File.ReadAllBytes(certificadoCap.Ruta));
                        dto.Participantes.Add(participanteDto);
                    }

                    listaResult.Add(dto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(e.ToString());
            }

            return listaResult;
        }
        
        // [HttpPost("generar-certificado")]
        // public async Task<ActionResult> GeneraCertificado
    }
}