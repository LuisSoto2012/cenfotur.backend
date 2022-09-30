namespace Cenfotur.Entidad.DTOS.Output
{
    public class FichaSupervision_O_DTO
    {
        public int FichaSupervisionId { get; set; }
        public int? CapacitacionId { get; set; }
        public int? CursoId { get; set; }
        public string Curso { get; set; }
        public string FechaSupervision { get; set; }
        public int? ProgramaId { get; set; }
        public string Programa { get; set; }
        public string DepartamentoId { get; set; }
        public string Departamento { get; set; }
        public int? SupervisorId { get; set; }
        public string Supervisor { get; set; }
        public int? FacilitadorId { get; set; }
        public string Facilitador { get; set; }
        public int? TipoSupervisionId { get; set; }
        public string TipoSupervision { get; set; }
        public int Calificacion { get; set; }
        public string Resultado { get; set; }
        public bool Activo { get; set; }
    }
}