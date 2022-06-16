using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class TipoDocumento_I_DTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "El Nombre no debe tener mas de 50 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(maximumLength: 15, ErrorMessage = "La abreviatura no debe tener mas de 15 caracteres")]
        public string NombreAbrev { get; set; }
        [Required(ErrorMessage = "El Id del usuario creacion es obligatorio")]
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
