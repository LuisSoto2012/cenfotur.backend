using System;
using Cenfotur.Entidad.Models;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class FichaSupervision_I_DTO
    {
        public int? CapacitacionId { get; set; }
        public DateTime? FechaSupervision { get; set; }
        public int? ProgramaId { get; set; }
        public string DepartamentoId { get; set; }
        public int? SupervisorId { get; set; }
        public int? FacilitadorId { get; set; }
        public int? TipoSupervisionId { get; set; }
        public int Calificacion { get; set; }
        public int? UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
    }
}