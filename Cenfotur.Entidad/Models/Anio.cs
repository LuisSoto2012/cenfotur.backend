using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Models
{
    public class Anio
    {
        public int AnioId { get; set; }
        [Required(ErrorMessage ="El Nombre del año es obligatorio")]
        [Column("Nombre", TypeName = "varchar(4)")]
        [StringLength(maximumLength: 4, ErrorMessage = "El año no puede tener mas de 4 caracteres")]
        public string Nombre { get; set; }
        [Column("NombreOficial", TypeName = "varchar(170)")]
        [StringLength(maximumLength: 170, ErrorMessage = "El nombre del año Ofocial no puede tener mas de 4 caracteres")]
        [Required]
        public string NombreOficial { get; set; }
        [Required]
        [Range(1000, 10000, ErrorMessage = "El monto no se encuentra en un rango adecuado")]
        public int UIT { get; set; }
        [Required]
        public int ConDirectaMonMax { get; set; }
        [Required(ErrorMessage = "El Id del usuario creacion es obligatorio")]
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

        public List<MetaPresupuestal> MetasPresupuestales { get; set; } // Uno a muchos Contrataciones es el hijo
        public List<Contratacion> Contrataciones { get; set; } // Uno a muchos Contrataciones es el hijo
    }
}
