using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Anio_I_DTO
    {
        [Required(ErrorMessage = "El Nombre del año es obligatorio")]
        [StringLength(maximumLength: 4, ErrorMessage = "El año no puede tener mas de 4 caracteres")]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 170, ErrorMessage = "El nombre del año Oficial no puede tener mas de 4 caracteres")]
        [Required]
        public string NombreOficial { get; set; }
        [Required]
        [Range(1000, 10000, ErrorMessage = "El monto no se encuentra en un rango adecuado")]
        public int UIT { get; set; }
        [Required]
        public int ConDirectaMonMax { get; set; }
        [Required]
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
