using System;
using System.Collections.Generic;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class CapacitacionCert_O_DTO
    {
        public int CapacitacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CursoId { get; set; }
        public string Curso { get; set; }
        public int? PerfilRelacionadoId { get; set; }
        public string PerfilRelacionado { get; set; }
        public int? Dias { get; set; }
        public int? Horas { get; set; }
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

        public Documentacion_O_DTO Documentacion { get; set; }
        public MaterialAcademico_O_DTO MaterialAcademico { get; set; }
        
        public bool Activo { get; set; }
    }
}