using System;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class RegistroPostulacion_O_DTO
    {
        public int CapacitacionId { get; set; }
        public string NombreCurso { get; set; }
        public int Horas { get; set; }
        public int Dias { get; set; }
        public int HorasMinimas { get; set; }
        public string Facilitador { get; set; }
        public string Estado { get; set; }
        public int TipoCapacitacionId { get; set; }
        public string TipoCapacitacion { get; set; }
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
        public bool PostuladoAceptado { get; set; }
    }
}