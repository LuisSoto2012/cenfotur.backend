using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class TipoDocumento_O_DTO
    {
        public int TipoDocumentoId { get; set; }
        public string Nombre { get; set; }
        public string NombreAbrev { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Activo { get; set; }
    }
}
