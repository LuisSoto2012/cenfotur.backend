using Microsoft.AspNetCore.Http;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class RegistrosParticipante_I_DTO
    {
        public IFormFile RegistroParticipante { get; set; }
        public IFormFile RegistroEmpresa { get; set; }
    }
}