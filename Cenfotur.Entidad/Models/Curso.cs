// Curso.cs18:1618:16

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Cenfotur.Entidad.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        [Column("Nombre", TypeName = "varchar(200)")]
        public string Nombre { get; set; }
        public int Horas { get; set; }
        [Column("Codigo", TypeName = "varchar(20)")]
        public string Codigo { get; set; }
        public int HorasAprobar { get; set; }
        [Column("Resolucion", TypeName = "varchar(100)")]
        public string Resolucion { get; set; }
        public decimal ExamenEntrada { get; set; }
        public int? PerfilRelacionadoId { get; set; }
        public PerfilRelacionado PerfilRelacionado { get; set; }
        public int Dias { get; set; }
        public decimal Final { get; set; }
        public decimal? Practica { get; set; }
        public bool? PracticaNoAplica { get; set; }
        public decimal? Practica2 { get; set; }
        public bool? PracticaNoAplica2 { get; set; }
        public decimal? Practica3 { get; set; }
        public bool? PracticaNoAplica3 { get; set; }
        public decimal? Practica4 { get; set; }
        public bool? PracticaNoAplica4 { get; set; }
        public decimal? Practica5 { get; set; }
        public bool? PracticaNoAplica5 { get; set; }
        public bool DesempenioNoAplica { get; set; }
        public bool FinalNoAplica { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }
        public bool Activo { get; set; }
        
        public ICollection<CursoPerfilRelacionado> CursoPerfilRelacionado { get; set; }
    }
}