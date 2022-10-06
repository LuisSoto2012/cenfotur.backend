using System.Collections.Generic;
using Cenfotur.Entidad.DTOS.Output;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class ExportarExcel_I_DTO
    {
        public IEnumerable<CapacitacionResumen_O_DTO> Data { get; set; }
    }
}