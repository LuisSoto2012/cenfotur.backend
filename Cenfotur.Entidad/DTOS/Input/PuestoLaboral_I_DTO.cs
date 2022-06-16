using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class PuestoLaboral_I_DTO
    {
        [Required(ErrorMessage = "El Nombre del Puesto Laboral es obligatorio")]
        [Column("Nombre", TypeName = "varchar(60)")]
        [StringLength(maximumLength: 60, ErrorMessage = "El Nombre del Puesto Laboral es obligatorio")]
        public string Nombre { get; set; }

        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
