using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class FichaSupervision
    {
        public int FichaSupervisionId { get; set; }
        public int? CapacitacionId { get; set; }
        public Capacitacion Capacitacion { get; set; }
        public DateTime? FechaSupervision { get; set; }
        public int? ProgramaId { get; set; }
        public Programa Programa { get; set; }
        public string DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public int? SupervisorId { get; set; }
        public Empleado Supervisor { get; set; }
        public int? FacilitadorId { get; set; }
        public Empleado Facilitador { get; set; }
        public int? TipoSupervisionId { get; set; }
        public TipoSupervision TipoSupervision { get; set; }
        public int Calificacion { get; set; }
        public string Resultado { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}