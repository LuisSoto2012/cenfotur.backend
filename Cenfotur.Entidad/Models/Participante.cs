// Participante.cs00:0700:07

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cenfotur.Entidad.Models
{
    public class Participante
    {
        public int ParticipanteId { get; set; }
        [Column("ApellidoPaterno", TypeName = "varchar(200)")]
        public string ApellidoPaterno { get; set; }
        [Column("ApellidoMaterno", TypeName = "varchar(200)")]
        public string ApellidoMaterno { get; set; }
        [Column("Nombres", TypeName = "varchar(200)")]
        public string Nombres { get; set; }
        public int? TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        [Column("NumeroDocumento", TypeName = "varchar(25)")]
        public string NumeroDocumento { get; set; }
        [Column("Nacionalidad", TypeName = "varchar(50)")]
        public string Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [Column("TelefonoMovil", TypeName = "varchar(20)")]
        public string TelefonoMovil { get; set; }
        [Column("CorreoElectronico", TypeName = "varchar(50)")]
        public string CorreoElectronico { get; set; }
        [Column("DomicilioActual", TypeName = "varchar(200)")]
        public string DomicilioActual { get; set; }
        public string DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public string ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public string DistritoId { get; set; }
        public Distrito Distrito { get; set; }
        
        [Column("TelefonoEmpresa", TypeName = "varchar(50)")]
        public string TelefonoEmpresa { get; set; }
        public int? PerfilRelacionadoId { get; set; }
        public PerfilRelacionado PerfilRelacionado { get; set; }
        [Column("CertificadoTrabajo", TypeName = "varchar(200)")]
        public string CertificadoTrabajo { get; set; }
        [Column("CertificadoEstudios", TypeName = "varchar(200)")]
        public string CertificadoEstudios { get; set; }
        [Column("Usuario", TypeName = "varchar(100)")]
        public string Usuario { get; set; }
        [Column("Contrasena", TypeName = "varchar(100)")]
        public string Contrasena { get; set; }

        public int? SexoId { get; set; }
        public Sexo Sexo { get; set; }
        [Column("LugarNacimiento", TypeName = "varchar(100)")]
        public string LugarNacimiento { get; set; }
        public int? EstadoCivilId { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public int? NivelEducativoId { get; set; }
        public NivelEducativo NivelEducativo { get; set; }
        public int? AlcanceId { get; set; }
        public Alcance Alcance { get; set; }
        [Column("GradoInstruccion", TypeName = "varchar(100)")]
        public string GradoInstruccion { get; set; }
        public bool? ConDiscapacidad { get; set; }
        [Column("TipoDiscapacidad", TypeName = "varchar(100)")]
        public string TipoDiscapacidad { get; set; }
        [Column("Codigo", TypeName = "varchar(20)")]
        public string Codigo { get; set; }
        [Column("ExperienciaLaboralGeneral", TypeName = "varchar(100)")]
        public string ExperienciaLaboralGeneral { get; set; }
        [Column("ExperienciaLaboralPerfil", TypeName = "varchar(100)")]
        public string ExperienciaLaboralPerfil { get; set; }
        public int? CargoDirectivoId { get; set; }
        public Cargo CargoDirectivo { get; set; }
        public int? CargoOperativoId { get; set; }
        public Cargo CargoOperativo { get; set; }
        [Column("ExperienciaEmpresa", TypeName = "varchar(100)")]
        public string ExperienciaEmpresa { get; set; }
        public int? TipoRemuneracionId { get; set; }
        public TipoRemuneracion TipoRemuneracion { get; set; }
        public decimal? Remuneracion { get; set; }
        public bool? AceptaCorreosOtros { get; set; }

        public int? EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaCreacion { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "No tiene el formato de fecha necesario")]
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }

        public bool Activo { get; set; }
        
        [Column("RegistroParticipante", TypeName = "varchar(200)")]
        public string RegistroParticipante { get; set; }
        [Column("RegistroEmpresa", TypeName = "varchar(200)")]
        public string RegistroEmpresa { get; set; }
        
        public ICollection<ParticipanteCapacitacion> ParticipanteCapacitacion { get; set; }
        public ICollection<EncuestaSatisfaccion> EncuestaSatisfaccion { get; set; }
        public ICollection<Asistencia> Asistencia { get; set; }
        public ICollection<Nota> Notas { get; set; }
    }
}