using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Rol_I_DTO
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [Required]
        public Boolean Activo { get; set; }
    }
}
