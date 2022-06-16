using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Models
{
    public class MetaPresupuestal
    {
        public int MetaPresupuestalId { get; set; }
        [Required(ErrorMessage = "El Nombre de la Meta Presupuestal es obligatorio")]
        [Column("Nombre", TypeName = "varchar(85)")]
        [StringLength(maximumLength: 85, ErrorMessage = "El nombre de la meta puede tener mas de 85 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Año Id es obligatorio")]
        public int? AnioId { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        [Required]
        public bool Activo { get; set; }


        public List<Contratacion> Contrataciones { get; set; } // Uno a muchos Contrataciones es el hijo 

    }
}
