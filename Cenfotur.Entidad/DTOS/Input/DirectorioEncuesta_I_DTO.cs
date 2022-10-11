using System;
using Cenfotur.Entidad.Models;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class DirectorioEncuesta_I_DTO
    {
        public string NombreDirector { get; set; }
        public string Institucion { get; set; }
        public string Cargo { get; set; }
        public string TelefonoMovil { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string ActorLocal { get; set; }
        public string DistritoId { get; set; }
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
        public int? UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
    }
}