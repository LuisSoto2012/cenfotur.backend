using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Contratacion_O_DTO
    {
        public int ContratacionId { get; set; }
        public int AnioId { get; set; }
        public int EmpleadoId { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int PuestoLaboralId { get; set; }

        public int MetaPresupuestalId { get; set; }
        public string OrdenServicio { get; set; }
        public string ContratacionDescripcion { get; set; }

        public decimal Remuneracion { get; set; }

        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Activo { get; set; }
    }
}
