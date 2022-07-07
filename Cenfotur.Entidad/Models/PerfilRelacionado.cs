// PerfilRelacionado.cs23:3823:38

using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class PerfilRelacionado
    {
        public int PerfilRelacionadoId { get; set; }
        [Column("Nombre", TypeName = "varchar(200)")]
        public string Nombre { get; set; }
        public bool Activo { get; set; }
    }
}