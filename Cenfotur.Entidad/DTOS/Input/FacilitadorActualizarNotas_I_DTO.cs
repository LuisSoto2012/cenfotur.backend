using System.Collections.Generic;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class FacilitadorActualizarNotas_I_DTO
    {
        public int CapacitacionId { get; set; }
        public int FacilitadorId { get; set; }
        public List<FacilitadorNotas_I_DTO> ParticipantesNotas { get; set; }
    }
}