// Empresa.cs21:1821:18

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        [Column("NombreCurso", TypeName = "varchar(200)")]
        public string NombreCurso { get; set; }
        [Column("Ruc", TypeName = "varchar(30)")]
        public string Ruc { get; set; }
        [Column("RazonSocial", TypeName = "varchar(200)")]
        public string RazonSocial { get; set; }
        [Column("NombreComercial", TypeName = "varchar(200)")]
        public string NombreComercial { get; set; }

        public int? TipoContribuyenteId { get; set; }
        public TipoContribuyente TipoContribuyente { get; set; }
        public int? RubroId { get; set; }
        public Rubro Rubro { get; set; }
        public int? DicerturId { get; set; }
        public Dicertur Dicertur { get; set; }
        public int? ClaseId { get; set; }
        public Clase Clase { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int Horas { get; set; }
        [Column("Direccion", TypeName = "varchar(200)")]
        public string Direccion { get; set; }
        public int? ReferenciaId { get; set; }
        public Referencia Referencia { get; set; }
        public string DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public string ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public string DistritoId { get; set; }
        public Distrito Distrito { get; set; }
        [Column("Codigo", TypeName = "varchar(20)")]
        public string Codigo { get; set; }
        [Column("TelefonoFijo", TypeName = "varchar(20)")]
        public string TelefonoFijo { get; set; }
        [Column("PaginaWeb", TypeName = "varchar(50)")]
        public string PaginaWeb { get; set; }
        [Column("WebInscrita", TypeName = "varchar(200)")]
        public string WebInscrita { get; set; }
        public bool AceptaCorreosOtros { get; set; }
        
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        
        public bool Activo { get; set; }
        
        public List<Participante> Participantes { get; set; }
    }
}