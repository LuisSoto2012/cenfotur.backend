// Documento.cs22:4922:49

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Documentacion
    {
        public int DocumentacionId { get; set; }
        public int CapacitacionId { get; set; }
        public Capacitacion Capacitacion { get; set; }
        [Column("TdrFacilitador", TypeName = "varchar(200)")]
        public string TdrFacilitador { get; set; }
        [Column("OsFacilitador", TypeName = "varchar(200)")]
        public string OsFacilitador { get; set; }
        [Column("TdrGestor", TypeName = "varchar(200)")]
        public string TdrGestor { get; set; }
        [Column("OsGestor", TypeName = "varchar(200)")]
        public string OsGestor { get; set; }
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