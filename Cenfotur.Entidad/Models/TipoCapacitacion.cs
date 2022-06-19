// TipoCapacitacion.cs22:4822:48

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class TipoCapacitacion
    {
        public int TipoCapacitacionId { get; set; }
        [Column("Nombre", TypeName = "varchar(200)")]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public List<Capacitacion> Capacitaciones { get; set; }
    }
}