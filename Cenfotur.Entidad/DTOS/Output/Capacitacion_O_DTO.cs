// Capacitacion_O_DTO.cs23:5923:59

using System;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Capacitacion_O_DTO
    {
        public int CapacitacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CursoId { get; set; }
        public string Curso { get; set; }
        public string PublicoObjetivo { get; set; }
        public int Dias { get; set; }
        public int Horas { get; set; }
        public int DistritoId { get; set; }
        public string Distrito { get; set; }
        public string ProvinciaId { get; set; }
        public string Provincia { get; set; }
        public string DepartamentoId { get; set; }
        public string Departamento { get; set; }
        public int TipoCapacitacionId { get; set; }
        public string TipoCapacitacion { get; set; }
        public int? FacilitadorId { get; set; }
        public string Facilitador { get; set; }
        public int? GestorId { get; set; }
        public string Gestor { get; set; }
        
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        
        public bool Activo { get; set; }
    }
}