// Asistencia_I_DTO.cs22:5022:50

using System.Collections.Generic;
using Cenfotur.Entidad.DTOS.Output;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Asistencia_I_DTO
    {
        public List<Asistencia_O_DTO> ListaAsistencia { get; set; }
        public int? FacilitadorId { get; set; }
        public int? SupervisorId { get; set; }
    }
}