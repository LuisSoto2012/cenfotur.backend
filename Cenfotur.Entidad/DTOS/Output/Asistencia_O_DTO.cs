using System.Collections.Generic;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Asistencia_O_DTO
    {
        public int ParticipanteId { get; set; }
        public int CapacitacionId { get; set; }
        public string NumeroDocumento { get; set; }
        public string Participante { get; set; }
        public List<FechaAsistencia_O_DTO> Fechas { get; set; }
    }
}