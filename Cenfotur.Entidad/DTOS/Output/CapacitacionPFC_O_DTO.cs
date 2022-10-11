using System;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class CapacitacionPFC_O_DTO
    {
        public int CapacitacionId { get; set; }
        public int? CursoId { get; set; }
        public string Curso { get; set; }
        public string TipoCapacitacion { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string PerfilRelacionado { get; set; }
        public int? Horas { get; set; }
        public int? Sesiones { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Gestor { get; set; }
        public string Facilitador { get; set; }
    }
}