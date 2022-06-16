using Cenfotur.Entidad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Modulo_I_DTO
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "El Nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        [StringLength(maximumLength: 50, ErrorMessage = "El Icono no puede tener mas de 50 caracteres")]
        public string Icono { get; set; } = string.Empty;
        [Required]
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [Required]
        public Boolean Activo { get; set; }

        //public List<SubModulo_O_DTO> SubModulos { get; set; } 
    }
}
