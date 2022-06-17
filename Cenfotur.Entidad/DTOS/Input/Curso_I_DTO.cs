// Curso_I_DTO.cs18:2818:28

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Curso_I_DTO
    {
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
        public bool Activo { get; set; }
    }
}