using Cenfotur.Entidad.DTOS.Output;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Models
{
    public class Modulo
    {
        public int ModuloId { get; set; }
        [Required]
        [Column("Nombre", TypeName = "varchar(100)")]
        [StringLength(maximumLength: 100, ErrorMessage = "El Nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        [Column("Icono", TypeName = "varchar(50)")]
        [StringLength(maximumLength: 50, ErrorMessage = "El Icono no puede tener mas de 50 caracteres")]
        public string Icono { get; set; } = string.Empty;

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

        public List<SubModulo> SubModulos { get; set; } // Uno a muchos Padre

        
    }
}
