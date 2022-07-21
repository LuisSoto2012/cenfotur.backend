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
    }
}