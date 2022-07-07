// Alcance.cs23:5223:52

using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Alcance
    {
        public int AlcanceId { get; set; }
        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}