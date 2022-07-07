// Cargo.cs23:5623:56

using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }
        [Column("Nombre", TypeName = "varchar(50)")]
        public string Nombre { get; set; }
        [Column("TipoCargo", TypeName = "varchar(1)")]
        public string TipoCargo { get; set; }
        public bool Activo { get; set; }
    }
}