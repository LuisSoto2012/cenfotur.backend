using Cenfotur.Entidad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Login_O_DTO
    {
        [Required(ErrorMessage ="El Usuario no puede estar en blanco")]
        public string Usuario { get; set; } = string.Empty;
        [Required(ErrorMessage = "La Contrasena no puede estar en blanco")]
        public string Contrasena { get; set; } = string.Empty;
        //public Boolean LoginEstado { get; set; }
        //public Boolean Activo { get; set; }

        // Para relacion mucho a muchos
        //public ICollection<EmpleadoRol> EmpleadoRol { get; set; }
    }
}
