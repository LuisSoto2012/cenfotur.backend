// FacilitadorArchivo.cs23:1923:19

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class FacilitadorArchivo
    {
        public int FacilitadorArchivoId { get; set; }
        [Required]
        public int FacilitadorId { get; set; }
        [Required]
        public int CapacitacionId { get; set; }
        [Column("Archivo", TypeName = "varchar(200)")]
        public string Archivo { get; set; }
        [Column("TipoArchivo", TypeName = "varchar(20)")]
        public string TipoArchivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

        // Relacion muchos a muchos
        public Empleado Facilitador { get; set; }
        public Capacitacion Capacitacion { get; set; }
    }
}