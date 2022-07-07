// NivelEducativo.cs23:5123:51

using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class NivelEducativo
    {
        public int NivelEducativoId { get; set; }
        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}