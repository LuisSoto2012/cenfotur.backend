using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Rol_O_DTO
    {
        public int RolId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Boolean Activo { get; set; }

        // traer data de RolSubModulo
        public List<RolSubModulo_O_DTO> RolSubModulo { get; set; } // Uno a muchos Padre --- ok
    }
}
