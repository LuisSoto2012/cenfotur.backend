using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Empleado_I_DTO
    {
        [StringLength(maximumLength: 100, ErrorMessage = "El Apellido Paterno no puede tener mas de 100 caracteres")]
        public string ApellidoPaterno { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "El Apellido Materno no puede tener mas de 100 caracteres")]
        public string ApellidoMaterno { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "El Nombre no puede tener mas de 100 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Parametro Sexo es obligatorio")]
        public int SexoId { get; set; }
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]

        public string TelefMovil { get; set; }
        [EmailAddress]
        [MaxLength(150, ErrorMessage = "Maximo 150 caracteres")]
        public string Correo { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime FechaNacimiento { get; set; }
        public int TipoDocumentoId { get; set; }
        [StringLength(maximumLength: 15, ErrorMessage = "El Número de documento no puede tener mas de 15 caracteres")]
        public string NumDoc { get; set; }
        [StringLength(maximumLength: 15, ErrorMessage = "El Nombre no puede tener mas de 15 caracteres")]
        public string Usuario { get; set; } = string.Empty;
        [StringLength(maximumLength: 50, ErrorMessage = "La Contraseña no puede tener mas de 50 caracteres")]
        public string Contrasena { get; set; } = string.Empty;
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public Boolean Activo { get; set; }
    }
}
