using System;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class DirectorioEncuesta_O_DTO
    {
        public int DirectorioEncuestaId { get; set; }
        public string NombreDirector { get; set; }
        public string Institucion { get; set; }
        public string Cargo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string ActorLocal { get; set; }
        public string Departamento { get; set; }
        public string DepartamentoId { get; set; }
        public string ProvinciaId { get; set; }
        public string Provincia { get; set; }
        public string DistritoId { get; set; }
        public string Distrito { get; set; }
        public DateTime? Fecha { get; set; }
        public string P1 { get; set; }
        public string P2 { get; set; }
        public string P3 { get; set; }
        public string P4 { get; set; }
        public string P5 { get; set; }
        public string P6 { get; set; }
        public string P7 { get; set; }
        public string P8 { get; set; }
        public string P9 { get; set; }
        public string P10 { get; set; }
        public string Recomendaciones { get; set; }
        public bool Activo { get; set; }
    }
}