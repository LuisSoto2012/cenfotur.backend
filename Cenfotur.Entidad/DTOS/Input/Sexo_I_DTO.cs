using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Sexo_I_DTO
    {
        [Required(ErrorMessage ="El Nombre de genero es obligatorio")]
        [Column("Nombre", TypeName = "varchar(15)")]
        [StringLength(maximumLength: 15, ErrorMessage = "El genero no puede tener mas de 15 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El usuario creación es obligatorio")]
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
