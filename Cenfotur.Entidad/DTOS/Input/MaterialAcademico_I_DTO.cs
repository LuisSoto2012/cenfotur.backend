// MaterialAcademico_I_DTO.cs22:0122:01

using Microsoft.AspNetCore.Http;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class MaterialAcademico_I_DTO
    {
        public int CapacitacionId { get; set; }
        public IFormFile FichaParticipante { get; set; }
        public IFormFile FichaEmpresa { get; set; }
        public IFormFile GesInstructivos { get; set; }
        public IFormFile GesFormatoInforme { get; set; }
        public IFormFile Sillabus { get; set; }
        public IFormFile Ppt { get; set; }
        public IFormFile Evaluaciones { get; set; }
        public IFormFile FacInstructivos { get; set; }
        public IFormFile FacFormatoInforme { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public bool Activo { get; set; }
    }
}