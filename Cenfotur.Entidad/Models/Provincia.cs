// Provincia.cs22:4122:41

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Provincia
    {
        public string ProvinciaId { get; set; }
        [Required]
        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public Departamento Departamento { get; set; }
        public List<Distrito> Distritos { get; set; }
    }
}