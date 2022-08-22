// FacilitadorArchivos_I_DTO.cs23:2723:27

using Microsoft.AspNetCore.Http;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class FacilitadorInforme_I_DTO
    {
        public int FacilitadorId { get; set; }
        public int CapacitacionId { get; set; }
        public IFormFile Informe { get; set; }
    }
}