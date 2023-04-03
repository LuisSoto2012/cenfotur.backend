// CursoPerfilRelacionado.cs23:1023:10

using System.ComponentModel.DataAnnotations;

namespace Cenfotur.Entidad.Models
{
    public class CursoPerfilRelacionado
    {
        [Required]
        public int CursoId { get; set; }
        [Required]
        public int PerfilRelacionadoId { get; set; }

        // -- Relacion muchos a muchos --
        public Curso Curso { get; set; }
        public PerfilRelacionado PerfilRelacionado { get; set; }
    }
}