using System;

namespace Cenfotur.Entidad.DTOS.Output
{
    public class ProgramacionInfoPFC_O_DTO
    {
        public int ProgramacionInfoPFCId { get; set; }
        public int? CapacitacionId { get; set; }
        public int? CursoId { get; set; }
        public string Curso { get; set; }
        public string TipoCapacitacion { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string PerfilRelacionado { get; set; }
        public int? Horas { get; set; }
        public int? Sesiones { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Gestor { get; set; }
        public string Facilitador { get; set; }
        public string OsFacilitador { get; set; }
        public int? DiasViatico { get; set; }
        public decimal? Honorarios { get; set; }
        public decimal? Viaticos { get; set; }
        public decimal? Pasajes { get; set; }
        public decimal? TotalCostoFacilitador { get; set; }
        public string GestorLocal { get; set; }
        public string OsGestor { get; set; }
        public decimal? CostoGestorLocal { get; set; }
        public string Sala { get; set; }
        public string IdZoom { get; set; }
        public string EnlaceAcceso { get; set; }
        public string Supervisa { get; set; }
        public DateTime? FechaSupervision { get; set; }
        public int? NroAprobados { get; set; }
        public int? NroDesaprobados { get; set; }
        public int? NroIpis { get; set; }
        public int? NroBeneficiarios { get; set; }
        public string PorcAprobados { get; set; }
        public string PorcDesaprobados { get; set; }
        public string PorcIpis { get; set; }
        public DateTime? FechaEmisionDiplomas { get; set; }
        public DateTime? FechaRecepcionDiplomas { get; set; }
        public string ContactoEnvioDiplomas { get; set; }
        public DateTime? FechaEnvioDiplomas { get; set; }
        public int? NroInscritos { get; set; }
        public string Observaciones { get; set; }
        public string DireccionPrincipal { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int? UsuarioModificacionId { get; set; }
    }
}