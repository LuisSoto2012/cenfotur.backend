// TipoRemuneracion.cs23:5723:57

using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class TipoRemuneracion
    {
        public int TipoRemuneracionId { get; set; }
        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}