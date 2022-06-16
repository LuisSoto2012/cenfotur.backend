using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Models
{
    public class Sexo
    {
        public int SexoId { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [Column("Nombre", TypeName = "varchar(15)")]
        [StringLength(maximumLength: 15, ErrorMessage = "El genero no puede tener mas de 15 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El usuario creación es obligatorio")]
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

    }
}
