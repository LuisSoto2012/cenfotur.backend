using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class SubModulo_I_DTO
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "El Nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        public string Ruta { get; set; } = string.Empty;
        [ForeignKey("Modulo")]
        public int ModuloId { get; set; }
        [Required]
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
