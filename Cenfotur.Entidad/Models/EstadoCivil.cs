// EstadoCivil.cs23:5023:50

using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class EstadoCivil
    {
        public int EstadoCivilId { get; set; }
        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}