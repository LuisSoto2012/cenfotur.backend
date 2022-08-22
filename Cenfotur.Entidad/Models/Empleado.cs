using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Models
{
    [Index(nameof(NumDoc), IsUnique = true)]
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        [Column("ApellidoPaterno", TypeName = "varchar(100)")]
        [StringLength(maximumLength: 100, ErrorMessage = "El Apellido Paterno no puede tener mas de 100 caracteres")]
        public string ApellidoPaterno { get; set; }
        [Required]
        [Column("ApellidoMaterno", TypeName = "varchar(100)")]
        [StringLength(maximumLength: 100, ErrorMessage = "El Apellido Materno no puede tener mas de 100 caracteres")]
        public string ApellidoMaterno { get; set; }
        [Required]
        [Column("Nombres", TypeName = "varchar(100)")]
        [StringLength(maximumLength: 100, ErrorMessage = "El Nombre no puede tener mas de 100 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage ="Parametro Sexo es obligatorio")]
        public int SexoId { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Column("TelefMovil", TypeName = "varchar(10)")]
        
        public string TelefMovil { get; set; }
        [EmailAddress(ErrorMessage ="El Formato del correo no es el correcto")]
        [MaxLength(150, ErrorMessage = "Maximo 150 caracteres")]
        [Column("Correo", TypeName = "varchar(150)")]
        public string Correo { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Column("FechaNacimiento", TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int TipoDocumentoId { get; set; }
        [Required]
        [Column("NumDoc", TypeName = "varchar(15)")]
        [StringLength(maximumLength: 15, ErrorMessage = "El Número de documento no puede tener mas de 15 caracteres")]
        public string NumDoc { get; set; }
        [Required]
        [Column("Usuario", TypeName = "varchar(15)")]
        [StringLength(maximumLength: 15, ErrorMessage = "El Usuario no puede tener mas de 15 caracteres")]
        public string Usuario { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "La Contraseña no puede tener mas de 50 caracteres")]
        [Column("Contrasena", TypeName = "varchar(50)")]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "El Id del usuario creacion es obligatorio")]
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

        // Para relacion mucho a muchos
        public ICollection<EmpleadoRol> EmpleadoRol { get; set; }
        public ICollection<FacilitadorArchivo> FacilitadorArchivos { get; set; }


        public List<Contratacion> Contrataciones { get; set; } // Uno a muchos Contratación es el hijo'

        public int? PuestoLaboralId { get; set; }
        public PuestoLaboral PuestoLaboral { get; set; }
    }
}
