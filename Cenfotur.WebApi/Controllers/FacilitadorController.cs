using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitadorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FacilitadorController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut("ActualizarNotas")]
        public async Task<ActionResult> ActualizarNotas([FromBody] FacilitadorNotas_I_DTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var registroDb = await _context.Notas.Include(n => n.Capacitacion.Curso).FirstOrDefaultAsync(x =>
                    x.ParticipanteId == dto.ParticipanteId && x.CapacitacionId == dto.CapacitacionId);

                if (registroDb != null)
                {
                    registroDb.Ee = dto.Ee;
                    registroDb.Ep = dto.Ep;
                    registroDb.Ed = dto.Ed;
                    registroDb.Ef = dto.Ef;
                    registroDb.Ef = dto.Ef == "IPI" ? "IPI" : await CalcularNF(registroDb);
                    registroDb.UsuarioModificacionId = dto.FacilitadorId;
                    registroDb.FechaModificacion = DateTime.Now;

                    _context.Update(registroDb);

                    await _context.SaveChangesAsync();

                    return Ok();
                }

                return NotFound("No se ha encontrado registro de Notas con dicho participante y capacitacioón");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            
            
        }

        private async Task<string> CalcularNF(Nota notaDb)
        {
            var cursoDb = notaDb.Capacitacion.Curso;
            string nf;
            
            //Validar si es IPI

            //Calcular dias necesarios de asistencia
            var horasMin = cursoDb.HorasAprobar;
            var horasTotal = cursoDb.Horas;
            var totalDias = (notaDb.Capacitacion.FechaFin - notaDb.Capacitacion.FechaInicio).TotalDays;
            var totalHorasPorDia = (int)(totalDias / horasTotal);
            var totalAsistenciasNecesarias = (int) horasMin / totalHorasPorDia;  
            
            //Validar asistencia
            var asistenciaParticipante = await _context.Asistencia.Where(x =>
                x.ParticipanteId == notaDb.ParticipanteId && x.CapacitacionId == notaDb.CapacitacionId && x.Asistio).ToListAsync();

            if (asistenciaParticipante.Count() < totalAsistenciasNecesarias)
            {
                nf = "IPI";
            }
            else
            {
                //Calcular NF
                decimal promPracticas = decimal.Parse(string.IsNullOrEmpty(notaDb.Ep) ? "0" : notaDb.Ep);
                decimal promExFinal = decimal.Parse(string.IsNullOrEmpty(notaDb.Ef) ? "0" : notaDb.Ef);

                var porcentajePractias = cursoDb.Practica ?? 0 + cursoDb.Practica2 ??
                    0 + cursoDb.Practica3 ?? 0 + cursoDb.Practica4 ?? 0 + cursoDb.Practica5 ?? 0;
                var porcentajeFinal = 1 - porcentajePractias;

                nf = Math.Round((promPracticas * porcentajePractias) + (promExFinal * porcentajeFinal), 0).ToString(CultureInfo.InvariantCulture);
            }
            
            return nf;
        }
        
    }
}