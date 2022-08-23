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
        public IFormFile FichaAsistencia { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public bool Activo { get; set; }
        
        public string RutaFichaParticipante { get; set; }
        public string RutaFichaEmpresa { get; set; }
        public string RutaGesInstructivos { get; set; }
        public string RutaGesFormatoInforme { get; set; }
        public string RutaSillabus { get; set; }
        public string RutaPpt { get; set; }
        public string RutaEvaluaciones { get; set; }
        public string RutaFacInstructivos { get; set; }
        public string RutaFacFormatoInforme { get; set; }
        public string RutaFichaAsistencia { get; set; }
    }
}