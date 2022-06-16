using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Models
{
    public class PuestoLaboral
    {
        public int PuestoLaboralId { get; set; }
        [Required(ErrorMessage = "El Nombre del Puesto Laboral es obligatorio")]
        [Column("Nombre", TypeName = "varchar(60)")]
        [StringLength(maximumLength: 60, ErrorMessage = "El Nombre del Puesto Laboral es obligatorio")]
        public string Nombre { get; set; }

        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        [Required]
        public bool Activo { get; set; }

        public List<Contratacion> Contrataciones { get; set; } // Uno a muchos Contrataciones es el hijo 
    }
}
