using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Models
{
    public class TipoDocumento
    {
        public int TipoDocumentoId { get; set; }
        [Required]
        [Column("Nombre", TypeName = "varchar(50)")]
        [StringLength(maximumLength: 50, ErrorMessage = "El Nombre no debe tener mas de 50 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [Column("NombreAbrev", TypeName = "varchar(15)")]
        [StringLength(maximumLength: 15, ErrorMessage = "La abreviatura no debe tener mas de 15 caracteres")]
        public string NombreAbrev { get; set; }
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


        public List<Empleado> Empleados { get; set; } // Uno a muchos Empleados es el hijo 

    }
}
