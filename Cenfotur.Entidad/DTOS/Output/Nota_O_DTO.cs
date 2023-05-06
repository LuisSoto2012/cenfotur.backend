using System.Security.AccessControl;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Nota_O_DTO
    {
        public string NumeroDocumento { get; set; }
        public int ParticipanteId { get; set; }
        public string Participante { get; set; }
        public string Ee { get; set; }
        public string Ep1 { get; set; }
        public string Ep2 { get; set; }
        public string Ep3 { get; set; }
        public string Ep4 { get; set; }
        public string Ep5 { get; set; }
        public string Ef { get; set; }
        public string Nf { get; set; }
        public string Letras { get; set; }
    }
}