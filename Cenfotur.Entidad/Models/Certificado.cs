using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Certificado
    {
        public int CertificadoId { get; set; }
        public int CapacitacionId { get; set; }
        public Capacitacion Capacitacion { get; set; }
        public string Codigo { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaCertificado { get; set; }
        public int ParticipanteId { get; set; }
        public Participante Participante { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Ruta { get; set; }
    }
}