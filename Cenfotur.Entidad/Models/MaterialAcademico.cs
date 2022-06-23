// MaterialAcademico.cs21:5321:53

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class MaterialAcademico
    {
        public int MaterialAcademicoId { get; set; }
        public int CapacitacionId { get; set; }
        public Capacitacion Capacitacion { get; set; }
        [Column("FichaParticipante", TypeName = "varchar(200)")]
        public string FichaParticipante { get; set; }
        [Column("FichaEmpresa", TypeName = "varchar(200)")]
        public string FichaEmpresa { get; set; }
        [Column("GesInstructivos", TypeName = "varchar(200)")]
        public string GesInstructivos { get; set; }
        [Column("GesFormatoInforme", TypeName = "varchar(200)")]
        public string GesFormatoInforme { get; set; }
        [Column("Sillabus", TypeName = "varchar(200)")]
        public string Sillabus { get; set; }
        [Column("Ppt", TypeName = "varchar(200)")]
        public string Ppt { get; set; }
        [Column("Evaluaciones", TypeName = "varchar(200)")]
        public string Evaluaciones { get; set; }
        [Column("FacInstructivos", TypeName = "varchar(200)")]
        public string FacInstructivos { get; set; }
        [Column("FacFormatoInforme", TypeName = "varchar(200)")]
        public string FacFormatoInforme { get; set; }
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