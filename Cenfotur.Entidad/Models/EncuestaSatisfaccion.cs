using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class EncuestaSatisfaccion
    {
        [Required]
        public int ParticipanteId { get; set; }
        [Required]
        public int CapacitacionId { get; set; }
        public int? FacilitadorId { get; set; }
        public Empleado Facilitador { get; set; }
        public string DistritoId { get; set; }
        public Distrito Distrito { get; set; }
        [Required]
        [Column("Eva1", TypeName = "varchar(1)")]
        public string Eva1 { get; set; }
        [Required]
        [Column("Eva2", TypeName = "varchar(1)")]
        public string Eva2 { get; set; }
        [Required]
        [Column("Eva3", TypeName = "varchar(1)")]
        public string Eva3 { get; set; }
        [Required]
        [Column("Eva4", TypeName = "varchar(1)")]
        public string Eva4 { get; set; }
        [Required]
        [Column("Eva5", TypeName = "varchar(1)")]
        public string Eva5 { get; set; }
        [Required]
        [Column("Eva6", TypeName = "varchar(1)")]
        public string Eva6 { get; set; }
        [Required]
        [Column("Eva7", TypeName = "varchar(1)")]
        public string Eva7 { get; set; }
        [Required]
        [Column("Eva8", TypeName = "varchar(1)")]
        public string Eva8 { get; set; }
        [Required]
        [Column("Eva9", TypeName = "varchar(1)")]
        public string Eva9 { get; set; }
        [Required]
        [Column("Eva10", TypeName = "varchar(1)")]
        public string Eva10 { get; set; }
        [Required]
        [Column("Eva11", TypeName = "varchar(1)")]
        public string Eva11 { get; set; }
        [Required]
        [Column("Eva12", TypeName = "varchar(1)")]
        public string Eva12 { get; set; }
        [Required]
        [Column("Eva13", TypeName = "varchar(1)")]
        public string Eva13 { get; set; }
        [Required]
        [Column("Mejora1", TypeName = "varchar(200)")]
        public string Mejora1 { get; set; }
        [Required]
        [Column("Mejora2", TypeName = "varchar(200)")]
        public string Mejora2 { get; set; }
        [Required]
        [Column("Mejora3", TypeName = "varchar(200)")]
        public string Mejora3 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        
        // -- Relacion muchos a muchos --
        public Participante Participante { get; set; }
        public Capacitacion Capacitacion { get; set; }
    }
}