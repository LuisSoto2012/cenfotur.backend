namespace Cenfotur.Entidad.DTOS.Output
{
    public class Curso_C_DTO
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int? PerfilRelacionadoId { get; set; }
        public int[] PerfilRelacionado { get; set; }
        public int? Dias { get; set; }
        public int? Horas { get; set; }
    }
}