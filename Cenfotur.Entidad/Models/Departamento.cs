// Departamento.cs22:4022:40

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Departamento
    {
        public string DepartamentoId { get; set; }
        [Required]
        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public List<Provincia> Provincias { get; set; }
        public List<Distrito> Distritos { get; set; }
    }
}