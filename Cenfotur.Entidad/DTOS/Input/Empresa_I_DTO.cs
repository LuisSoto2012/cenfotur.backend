// Empresa_I_DTO.cs21:3021:30

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Empresa_I_DTO
    {
        public string NombreCurso { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string TipoContribuyente { get; set; }
        public int? RubroId { get; set; }
        public int? DicerturId { get; set; }
        public int? ClaseId { get; set; }
        public int? CategoriaId { get; set; }
        public int Horas { get; set; }
        public string Direccion { get; set; }
        public int? ReferenciaId { get; set; }
        public string DepartamentoId { get; set; }
        public string ProvinciaId { get; set; }
        public string DistritoId { get; set; }
        public string Codigo { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string PaginaWeb { get; set; }
        public string[] WebInscrita { get; set; }
        public bool AceptaCorreosOtros { get; set; }
        
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }

        public bool Activo { get; set; }
    }
}