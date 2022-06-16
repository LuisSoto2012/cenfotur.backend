using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Modulo_1_O_DTO
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

        public List<SubModulo_O_DTO> SubModulos { get; set; }
    }
}
