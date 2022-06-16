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
    public class Rol
    {
        public int RolId { get; set; }
        [Required]
        [Column("Nombre", TypeName = "varchar(150)")]
        public string Nombre { get; set; } = string.Empty;
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


        public ICollection<EmpleadoRol> EmpleadoRol { get; set; } // Para relación mucho a muchos empleado y rol // ok
        public ICollection<RolSubModulo> RolSubModulo { get; set; } /// -- ok


        // Para relación mucho a muchos rol SubModulo esto no me funciona en mapper hay q cambia la otra tabla
        //public RolSubModulo RolSubModulo { get; set; }
        //public List<RolSubModulo_O_DTO> RolSubModulo { get; set; } // Uno a muchos Padre
    }
}
