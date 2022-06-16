using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Entidades.Contrataciones
{
    public class ContratacionListado_E
    {
        public long EmpleadoId { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public int SexoId { get; set; }
        public string TelefMovil { get; set; }
        public string Correo { get; set; }
        public int TipoDocumentoId { get; set; }
        public string TipoDocAbrevNombre { get; set; }
        public string NumDoc { get; set; }
        public string FechaNacimiento { get; set; }
        public int ContratacionId { get; set; }
        public string FechaContratacion { get; set; }
        public int PuestoLaboralId { get; set; }
        public string PuestoLaboralNombre { get; set; }
        public int MetaPresupuestalId { get; set; }
        public string MetaPresupuestalNombre { get; set; }
        public string OrdenServicio { get; set; }
        public string ContratacionDescripcion { get; set; }
        public string Remuneracion { get; set; }
        public string TotalContrataciones { get; set; }
        public string Habilitacion { get; set; }
        public string ArchivoOrdenServicio { get; set; }
    }

}
