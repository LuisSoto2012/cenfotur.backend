﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.Models
{
    public class SubModulo
    {
        public int SubModuloId { get; set; }
        [Required]
        [Column("Nombre", TypeName = "varchar(100)")]
        [StringLength(maximumLength: 100, ErrorMessage = "El Nombre no debe tener mas de 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        public int Orden { get; set; }
        [Column("Ruta", TypeName = "varchar(200)")]
        public string Ruta { get; set; } = string.Empty;
        [ForeignKey("Modulo")]
        public int ModuloId { get; set; }
        [Required(ErrorMessage = "El Id del usuario creacion es obligatorio")]
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

        // Para relación mucho a muchos rol SubModulo esto no me funciona en mapper hay q cambia la otra tabla
        //public ICollection<RolSubModulo> RolSubModulo { get; set; } 
        public RolSubModulo RolSubModulo { get; set; } // es para llegar a la 3 tabla for member
    }
}
