using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    [Index("RolId", IsUnique = false)]
    [Index("SubModuloId", IsUnique = false)]
    public class RolSubModulo
    {
        public int RolSubModuloId { get; set; }
        [Required(ErrorMessage = "El RolId es obigatorio")]
        public int RolId { get; set; }
        [Required(ErrorMessage = "El SubModuloId es obigatorio")]
        public int SubModuloId { get; set; }
        [NotMapped]
        public string SubModuloNombre { get; set; }
        [NotMapped]
        public string SubModuloRuta { get; set; }
        [Required(ErrorMessage = "Permiso ver es obligatorio")]
        public bool Ver { get; set; }
        [Required(ErrorMessage = "Permiso agregar es obligatorio")]
        public bool Agregar { get; set; }
        [Required(ErrorMessage = "Permiso editar es obligatorio")]
        public bool Editar { get; set; }
        [Required(ErrorMessage = "Permiso eliminar es obligatorio")]
        public bool Eliminar { get; set; }
        [Required(ErrorMessage ="El Id del usuario creacion es obligatorio")]
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
        // Relacion muchos a muchos
        public Rol Rol { get; set; }
        public SubModulo SubModulo { get; set; }
    }
}