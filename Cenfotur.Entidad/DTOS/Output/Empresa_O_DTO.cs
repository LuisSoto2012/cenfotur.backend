// Empresa_O_DTO.cs21:3721:37

using System;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Empresa_O_DTO
    {
        public int EmpresaId { get; set; }
        public string NombreCurso { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public int? TipoContribuyenteId { get; set; }
        public string TipoContribuyente { get; set; }
        public int? RubroId { get; set; }
        public string Rubro { get; set; }
        public int? DicerturId { get; set; }
        public string Dicertur { get; set; }
        public int? ClaseId { get; set; }
        public string Clase { get; set; }
        public int? CategoriaId { get; set; }
        public string Categoria { get; set; }
        public int Horas { get; set; }
        public string Direccion { get; set; }
        public int? ReferenciaId { get; set; }
        public string Referencia { get; set; }
        public string DepartamentoId { get; set; }
        public string Departamento { get; set; }
        public string ProvinciaId { get; set; }
        public string Provincia { get; set; }
        public string DistritoId { get; set; }
        public string Distrito { get; set; }
        public string Codigo { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string PaginaWeb { get; set; }
        public string[] WebInscrita { get; set; }
        public bool AceptaCorreosOtros { get; set; }
        
        public int UsuarioCreacionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }

        public bool Activo { get; set; }
    }
}