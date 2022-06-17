// Curso_O_DTO.cs18:5718:57

using System;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Curso_O_DTO
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int Horas { get; set; }
        public string Codigo { get; set; }
        public int HorasAprobar { get; set; }
        public string Resolucion { get; set; }
        public decimal ExamenEntrada { get; set; }
        public string PublicoObjetivo { get; set; }
        public decimal Practica { get; set; }
        public int Dias { get; set; }
        public decimal Desempenio { get; set; }
        public decimal Final { get; set; }
        public bool PracticaNoAplica { get; set; }
        public bool DesempenioNoAplica { get; set; }
        public bool FinalNoAplica { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public bool Activo { get; set; }
    }
}