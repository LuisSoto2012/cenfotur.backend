// Participacion_O_DTO.cs12:5812:58

using System;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class Participante_O_DTO
    {
        public int ParticipanteId { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreoElectronico { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string DepartamentoId { get; set; }
        public string Departamento { get; set; }
        public string TelefonoEmpresa { get; set; }
        public int? PerfilRelacionadoId { get; set; }
        public string PerfilRelacionado { get; set; }
        public string ArchivoCertificadoTrabajo { get; set; }
        public string ArchivoCertificadoEstudios { get; set; }
        public string RutaCertificadoTrabajo { get; set; }
        public string RutaCertificadoEstudios { get; set; }
        public bool Activo { get; set; }
        
        public string DomicilioActual { get; set; }
        public string ProvinciaId { get; set; }
        public string Provincia { get; set; }
        public string DistritoId { get; set; }
        public string Distrito { get; set; }
        public int? SexoId { get; set; }
        public string Sexo { get; set; }
        public string LugarNacimiento { get; set; }
        public int? EstadoCivilId { get; set; }
        public string EstadoCivil { get; set; }
        public int? NivelEducativoId { get; set; }
        public string NivelEducativo { get; set; }
        public int? AlcanceId { get; set; }
        public string Alcance { get; set; }
        public string GradoInstruccion { get; set; }
        public bool? ConDiscapacidad { get; set; }
        public string TipoDiscapacidad { get; set; }
        public string Codigo { get; set; }
        public string TelefonoFijo { get; set; }
        public string ExperienciaLaboralGeneral { get; set; }
        public string ExperienciaLaboralPerfil { get; set; }
        public int? CargoDirectivoId { get; set; }
        public string CargoDirectivo { get; set; }
        public int? CargoOperativoId { get; set; }
        public string CargoOperativo { get; set; }
        public string ExperienciaEmpresa { get; set; }
        public int? TipoRemuneracionId { get; set; }
        public string TipoRemuneracion { get; set; }
        public decimal? Remuneracion { get; set; }
        public bool? AceptaCorreosOtros { get; set; }

        public string Certificado { get; set; }
        
    }
}