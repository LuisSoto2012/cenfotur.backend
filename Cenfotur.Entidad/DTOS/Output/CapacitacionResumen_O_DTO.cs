using System;
using System.Collections.Generic;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class CapacitacionResumen_O_DTO
    {
        public int CapacitacionId { get; set; }
        public int CursoId { get; set; }
        public string Curso { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int DistritoId { get; set; }
        public string Distrito { get; set; }
        public string ProvinciaId { get; set; }
        public string Provincia { get; set; }
        public string DepartamentoId { get; set; }
        public string Departamento { get; set; }
        public int? FacilitadorId { get; set; }
        public string Facilitador { get; set; }
        public int TipoCapacitacionId { get; set; }
        public string TipoCapacitacion { get; set; }
        public List<Asistencia_O_DTO> Asistencias { get; set; }
        public List<Nota_O_DTO> Notas { get; set; }
        public List<CapacitacionConsolidado_O_DTO> Consolidado { get; set; }
    }
}