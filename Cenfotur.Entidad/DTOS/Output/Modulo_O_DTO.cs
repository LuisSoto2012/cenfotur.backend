using Cenfotur.Entidad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Modulo_O_DTO
    {
        public int ModuloId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        public string Icono { get; set; } = string.Empty;
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public Boolean Activo { get; set; }
        
        // Uno a muchos Padre funcionando con mapper
        //public List<SubModulo_O_DTO> SubModulos { get; set; }


        public List<RolSubModulo_O_DTO> RolSubModulo { get; set; }  // es para llegar a la 3 tabla for member
        



        //public List<SubModulo> SubModulos { get; set; } // Uno a muchos Padre
    }
}
