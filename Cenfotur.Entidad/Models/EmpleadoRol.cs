using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Models
{
    public class EmpleadoRol
    {
        [Required]
        public int EmpleadoId { get; set; }
        [Required]
        public int RolId { get; set; }

        // -- Relacion muchos a muchos --
        public Empleado Empleado { get; set; }
        public Rol Rol { get; set; }
    }
}
