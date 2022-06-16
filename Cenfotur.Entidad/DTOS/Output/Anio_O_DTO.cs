using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Anio_O_DTO
    {
        public int AnioId { get; set; }
        [StringLength(maximumLength: 4, ErrorMessage = "El año no puede tener mas de 4 caracteres")]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 170, ErrorMessage = "El nombre del año Oficial no puede tener mas de 4 caracteres")]
        public string NombreOficial { get; set; }
        [Range(1000, 10000, ErrorMessage = "El monto no se encuentra en un rango adecuado")]
        public int UIT { get; set; }
        public int ConDirectaMonMax { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        public DateTime? FechaModificacion { get; set; }
        public bool Activo { get; set; }
    }
}
