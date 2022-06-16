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
    public class SubModulo_O_DTO
    {
        public int SubModuloId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        public string Ruta { get; set; } = string.Empty;
        public int ModuloId { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Activo { get; set; }

        //public List<RolSubModulo_O_DTO> RolSubModulo { get; set; }

        //public ICollection<RolSubModulo> RolSubModulo { get; set; } // Para relación mucho a muchos rol SubModulo
    }
}
