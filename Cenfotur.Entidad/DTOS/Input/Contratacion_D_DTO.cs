using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Contratacion_D_DTO
    {
        public int ContratacionId { get; set; }
        //public DateTime? FechaModificacion { get; set; }
        public int UsuarioModificacionId { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
