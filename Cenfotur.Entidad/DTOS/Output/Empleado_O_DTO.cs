using Cenfotur.Entidad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Empleado_O_DTO
    {
        
        public int EmpleadoId { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public int SexoId { get; set; }
        public string TelefMovil { get; set; }
        public string Correo { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        //https://www.koskila.net/help-my-asp-net-mvc-textbox-date-format-is-wrong/
        //public string FechaNacimientoCorta { get { return FechaNacimiento.ToString("yyyy-MM-dd"); } }
        public int TipoDocumentoId { get; set; }
        public string NumDoc { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;

        public int UsuarioCreacionId { get; set; }
        public int UsuarioModificacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Boolean Activo { get; set; }

        // Para relacion mucho a muchos
        //public ICollection<EmpleadoRol> EmpleadoRol { get; set; }
    }
}
