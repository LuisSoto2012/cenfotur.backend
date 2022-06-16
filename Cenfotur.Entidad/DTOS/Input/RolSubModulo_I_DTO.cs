using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class RolSubModulo_I_DTO
    {
        [Required(ErrorMessage ="El RolId es obigatorio")]
        public int RolId { get; set; }
        [Required(ErrorMessage = "El SubModuloId es obigatorio")]
        public int SubModuloId { get; set; }
        public bool Ver { get; set; }
        public bool Agregar { get; set; }
        public bool Editar { get; set; }
        public bool Eliminar { get; set; }
        [Required(ErrorMessage = "El Id del usuario creacion es obligatorio")]
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [Required]
        public bool Activo { get; set; }

        //public Rol Rol { get; set; }
        //public SubModulo SubModulo { get; set; }
    }
}
