// ParticipantePerfilRelacionado.cs23:2223:22

using System.ComponentModel.DataAnnotations;

namespace Cenfotur.Entidad.Models
{
    public class ParticipantePerfilRelacionado
    {
        [Required]
        public int ParticipanteId { get; set; }
        [Required]
        public int PerfilRelacionadoId { get; set; }

        // -- Relacion muchos a muchos --
        public Participante Participante { get; set; }
        public PerfilRelacionado PerfilRelacionado { get; set; }
    }
}