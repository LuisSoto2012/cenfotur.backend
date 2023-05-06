using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Nota
    {
        [Required]
        public int ParticipanteId { get; set; }
        [Required]
        public int CapacitacionId { get; set; }
        [Column("EE", TypeName = "varchar(20)")]
        public string Ee { get; set; }
        [Column("EP1", TypeName = "varchar(20)")]
        public string Ep1 { get; set; }
        [Column("EP2", TypeName = "varchar(20)")]
        public string Ep2 { get; set; }
        [Column("EP3", TypeName = "varchar(20)")]
        public string Ep3 { get; set; }
        [Column("EP4", TypeName = "varchar(20)")]
        public string Ep4 { get; set; }
        [Column("EP5", TypeName = "varchar(20)")]
        public string Ep5 { get; set; }
        [Column("EF", TypeName = "varchar(20)")]
        public string Ef { get; set; }
        [Column("NF", TypeName = "varchar(20)")]
        public string Nf { get; set; }
        [Column("Letras", TypeName = "varchar(20)")]
        public string Letras { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        public int? FacilitadorId { get; set; }
        public Empleado Facilitador { get; set; }
        public int? SupervisorId { get; set; }
        public Empleado Supervisor { get; set; }
        
        // -- Relacion muchos a muchos --
        public Participante Participante { get; set; }
        public Capacitacion Capacitacion { get; set; }
    }
}