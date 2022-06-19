// Capacitacion_I_DTO.cs23:5223:52

using System;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Capacitacion_I_DTO
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Nombre { get; set; }
        public string PublicoObjetivo { get; set; }
        public int Dias { get; set; }
        public int Horas { get; set; }
        public string DistritoId { get; set; }
        public int TipoCapacitacionId { get; set; }
        public int? FacilitadorId { get; set; }
        public int? GestorId { get; set; }

        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        
        public bool Activo { get; set; }
    }
}