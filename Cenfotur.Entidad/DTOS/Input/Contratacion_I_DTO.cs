using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Contratacion_I_DTO
    {
        [Required(ErrorMessage = "El Año Id es obligatorio")]
        public int? AnioId { get; set; }
        [Required(ErrorMessage = "El Empleado Id es obligatorio")]
        public int EmpleadoId { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }
        [Required(ErrorMessage = "El valor Id del Puesto LaboraL es obligatorio")]
        public int PuestoLaboralId { get; set; }

        [Required(ErrorMessage = "El valor Id de la Meta Presupuestal es obligatorio")]
        public int MetaPresupuestalId { get; set; }

        [Column("OrdenServicio", TypeName = "varchar(40)")]
        public string OrdenServicio { get; set; }
        [Column("ContratacionDescripcion", TypeName = "varchar(100)")]
        public string ContratacionDescripcion { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Remuneracion { get; set; }

        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        [Required]
        public bool Activo { get; set; }
    }
}
