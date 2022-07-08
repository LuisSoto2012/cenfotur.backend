// Documento_I_DTO.cs22:5422:54

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Cenfotur.Entidad.Models;
using Microsoft.AspNetCore.Http;

namespace Cenfotur.Entidad.DTOS.Input
{
    public class Documentacion_I_DTO
    {
        public int CapacitacionId { get; set; }
        public IFormFile TdrFacilitador { get; set; }
        public IFormFile OsFacilitador { get; set; }
        public IFormFile TdrGestor { get; set; }
        public IFormFile OsGestor { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        public bool Activo { get; set; }
        public string RutaTdrFacilitador { get; set; }
        public string RutaOsFacilitador { get; set; }
        public string RutaTdrGestor { get; set; }
        public string RutaOsGestor { get; set; }
    }
}