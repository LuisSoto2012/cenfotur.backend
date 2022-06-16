using Cenfotur.Entidad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    
    public class RolSubModulo_O_DTO
    {
        public int RolSubModuloId { get; set; }
        public int RolId { get; set; }
        public int SubModuloId { get; set; }
        public string SubModuloNombre { get; set; }
        public string SubModuloRuta { get; set; }

        [Required(ErrorMessage = "Permiso ver es obligatorio")]
        public bool Ver { get; set; }
        [Required(ErrorMessage = "Permiso agregar es obligatorio")]
        public bool Agregar { get; set; }
        [Required(ErrorMessage = "Permiso editar es obligatorio")]
        public bool Editar { get; set; }
        [Required(ErrorMessage = "Permiso eliminar es obligatorio")]
        public bool Eliminar { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Activo { get; set; }

        //public Rol Rol { get; set; }
        //public SubModulo SubModulo { get; set; }
    }
}
