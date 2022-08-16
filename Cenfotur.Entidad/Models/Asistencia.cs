using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Asistencia
    {
        [Required]
        public int ParticipanteId { get; set; }
        [Required]
        public int CapacitacionId { get; set; }
        [Required]
        public DateTime FechaAsistencia { get; set; }
        [Required]
        public bool Asistio { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        
        // -- Relacion muchos a muchos --
        public Participante Participante { get; set; }
        public Capacitacion Capacitacion { get; set; }
    }
}