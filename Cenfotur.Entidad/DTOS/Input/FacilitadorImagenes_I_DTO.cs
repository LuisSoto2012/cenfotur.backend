// FacilitadorImagenes_I_DTO.cs23:5323:53

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class FacilitadorImagenes_I_DTO
    {
        public int FacilitadorId { get; set; }
        public int CapacitacionId { get; set; }
        public IList<IFormFile> Imagenes { get; set; }
    }
}