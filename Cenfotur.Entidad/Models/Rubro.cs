// Rubro.cs21:0321:03

using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Rubro
    {
        public int RubroId { get; set; }
        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}