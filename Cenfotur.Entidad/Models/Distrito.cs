// Distrito.cs22:4322:43

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Distrito
    {
        public string DistritoId { get; set; }
        [Required]
        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        public Provincia Provincia { get; set; }
        public Departamento Departamento { get; set; }
        
        public virtual List<Capacitacion> Capacitaciones { get; set; }
    }
}