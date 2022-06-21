// Capacitacion.cs21:2421:24

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cenfotur.Entidad.DTOS.Output;

namespace Cenfotur.Entidad.Models
{
    public class Capacitacion
    {
        public int CapacitacionId { get; set; }
        [DataType(DataType.Date)]
        [Column("FechaInicio", TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaInicio { get; set; }
        [Column("FechaFin", TypeName = "Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FechaFin { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        [Column("PublicoObjetivo", TypeName = "varchar(100)")]
        public string PublicoObjetivo { get; set; }
        public int Dias { get; set; }
        public int Horas { get; set; }
        public string UbigueoId { get; set; }
        public Distrito Ubigeo { get; set; }
        public int TipoCapacitacionId { get; set; }
        public TipoCapacitacion TipoCapacitacion { get; set; }
        public int? FacilitadorId { get; set; }
        public Empleado Facilitador { get; set; }
        public int? GestorId { get; set; }
        public Empleado Gestor { get; set; }
        
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        
        public bool Activo { get; set; }
        
        
    }
}