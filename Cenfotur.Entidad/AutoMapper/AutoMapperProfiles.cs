using AutoMapper;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cenfotur.Entidad.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Empleado_I_DTO, Empleado>(); // Inserta
            CreateMap<Empleado, Empleado_O_DTO>()
                .ForMember(r => r.RolId, x => x.MapFrom(c => c.EmpleadoRol.FirstOrDefault() == null ? 0 : c.EmpleadoRol.First().RolId))
                .ForMember(r => r.PuestoLaboralId, x => x.MapFrom(c => c.PuestoLaboralId))
                .ForMember(r => r.PuestoLaboral, x => x.MapFrom(c => c.PuestoLaboral == null ? "" : c.PuestoLaboral.Nombre)); // Lee

            CreateMap<PuestoLaboral_I_DTO, PuestoLaboral>(); // Inserta
            CreateMap<PuestoLaboral, PuestoLaboral_O_DTO>(); // Lee

            CreateMap<Modulo_I_DTO, Modulo>(); // Inserta
            CreateMap<Modulo, Modulo_O_DTO>() // Lee
                                             .ForMember(Modulo_O_DTO => Modulo_O_DTO.RolSubModulo, opciones => opciones.MapFrom(MapModuloDTORolSubModulo));
            CreateMap<Modulo, Modulo_1_O_DTO>();


            //CreateMap<EmpleadoContratacion_I_DTO, Empleado>();

            //CreateMap<Modulo, Modulo_RolSubModulo_O_DTO>
            //    .ForMember(Modulo_RolSubModulo_O_DTO => Modulo_RolSubModulo_O_DTO.RolSubModulo, opciones => opciones.MapFrom(MapModuloDTORolSubModulo));

            CreateMap<SubModulo_I_DTO, SubModulo>(); // Inserta
            CreateMap<SubModulo, SubModulo_O_DTO>(); // Lee
                //.ForMember(SubModulo_O_DTO => SubModulo_O_DTO.RolSubModulo, opciones => opciones.MapFrom(MapSubModuloDTORolSubModulo));



            CreateMap<RolSubModulo_I_DTO, RolSubModulo>(); // Inserta
            CreateMap<RolSubModulo, RolSubModulo_O_DTO>(); // Lee
                
            CreateMap<Rol_I_DTO, Rol>(); // Inserta
            CreateMap<Rol, Rol_O_DTO>(); // Lee

            CreateMap<Empleado, Login_O_DTO>(); // Lee

            CreateMap<Anio_I_DTO, Anio>(); // Inserta
            CreateMap<Anio, Anio_O_DTO>(); // Lee

            CreateMap<Sexo_I_DTO, Sexo>(); // Inserta
            CreateMap<Sexo, Sexo_O_DTO>(); // Lee

            CreateMap<TipoDocumento_I_DTO, TipoDocumento>(); // Inserta
            CreateMap<TipoDocumento, TipoDocumento_O_DTO>(); // Lee


            // ------------------- Contratación -------------------
            CreateMap<Contratacion_I_DTO, Contratacion>(); // Inserta
            CreateMap<Contratacion, Contratacion_O_DTO>(); // Lee

            CreateMap<MetaPresupuestal_I_DTO, MetaPresupuestal>(); // Inserta
            CreateMap<MetaPresupuestal, MetaPresupuestal_O_DTO>(); // Lee


            CreateMap<Curso_I_DTO, Curso>(); // Inserta
            CreateMap<Curso, Curso_O_DTO>()
                .ForMember(r => r.PerfilRelacionado, x => x.MapFrom(e => e.PerfilRelacionado != null ? e.PerfilRelacionado.Nombre : "")); // Lee
            
            
            //Comunes
            CreateMap<Departamento, Departamento_O_DTO>();
            CreateMap<Provincia, Provincia_O_DTO>();
            CreateMap<Distrito, Distrito_O_DTO>();
            CreateMap<TipoCapacitacion, TipoCapacitacion_O_DTO>();
            CreateMap<Empleado, Facilitador_O_DTO>()
                .ForMember(r => r.FacilitadorId, x => x.MapFrom(e => e.EmpleadoId))
                .ForMember(r => r.Nombre, x => x.MapFrom(e => string.Concat(e.NumDoc, " - ", e.Nombres, " ", e.ApellidoPaterno, " ", e.ApellidoMaterno).ToUpper()));
            CreateMap<Empleado, Gestor_O_DTO>()
                .ForMember(r => r.GestorId, x => x.MapFrom(e => e.EmpleadoId))
                .ForMember(r => r.Nombre, x => x.MapFrom(e => string.Concat(e.NumDoc, " - ", e.Nombres, " ", e.ApellidoPaterno, " ", e.ApellidoMaterno).ToUpper()));
            CreateMap<Curso, Curso_C_DTO>()
                .ForMember(r => r.PerfilRelacionadoId, x => x.MapFrom(e => e.PerfilRelacionadoId))
                .ForMember(r => r.PerfilRelacionado, x => x.MapFrom(e => e.PerfilRelacionado == null ? "" : e.PerfilRelacionado.Nombre));
            CreateMap<EstadoCivil, EstadoCivil_C_DTO>();
            CreateMap<NivelEducativo, NivelEducativo_C_DTO>();
            CreateMap<Alcance, Alcance_C_DTO>();
            CreateMap<Cargo, Cargo_C_DTO>();
            CreateMap<TipoRemuneracion, TipoRemuneracion_C_DTO>();
            CreateMap<Categoria, Categoria_C_DTO>();
            CreateMap<Clase, Clase_C_DTO>();
            CreateMap<Dicertur, Dicertur_C_DTO>();
            CreateMap<Referencia, Referencia_C_DTO>();
            CreateMap<Rubro, Rubro_C_DTO>();
            CreateMap<TipoContribuyente, TipoContribuyente_C_DTO>();
            CreateMap<Programa, Programa_C_DTO>();
            CreateMap<TipoSupervision, TipoSupervision_C_DTO>();
            
            //Capacitaciones
            CreateMap<Capacitacion_I_DTO, Capacitacion>()
                .ForMember(r => r.UbigueoId, x => x.MapFrom(c => c.DistritoId)); // Inserta
            CreateMap<Capacitacion, CapacitacionResumen_O_DTO>()
                .ForMember(r => r.DistritoId, x => x.MapFrom(c => c.UbigueoId))
                .ForMember(r => r.Distrito, x => x.MapFrom(c => c.Ubigeo.Nombre))
                .ForMember(r => r.ProvinciaId, x => x.MapFrom(c => c.Ubigeo.Provincia.ProvinciaId))
                .ForMember(r => r.Provincia, x => x.MapFrom(c => c.Ubigeo.Provincia.Nombre))
                .ForMember(r => r.DepartamentoId, x => x.MapFrom(c => c.Ubigeo.Departamento.DepartamentoId))
                .ForMember(r => r.Departamento, x => x.MapFrom(c => c.Ubigeo.Departamento.Nombre))
                .ForMember(r => r.TipoCapacitacionId, x => x.MapFrom(c => c.TipoCapacitacionId))
                .ForMember(r => r.TipoCapacitacion, x => x.MapFrom(c => c.TipoCapacitacion.Nombre))
                .ForMember(r => r.FacilitadorId, x => x.MapFrom(c => c.FacilitadorId))
                .ForMember(r => r.Facilitador,
                    x => x.MapFrom(c =>
                        c.Facilitador == null
                            ? ""
                            : string.Concat(c.Facilitador.Nombres, " ", c.Facilitador.ApellidoPaterno, " ",
                                c.Facilitador.ApellidoMaterno)))
                .ForMember(r => r.Curso, x => x.MapFrom(c => c.Curso.Nombre));
            CreateMap<Capacitacion, Capacitacion_O_DTO>()
                .ForMember(r => r.DistritoId, x => x.MapFrom(c => c.UbigueoId))
                .ForMember(r => r.Distrito, x => x.MapFrom(c => c.Ubigeo.Nombre))
                .ForMember(r => r.PerfilRelacionadoId, x => x.MapFrom(c => c.Curso.PerfilRelacionadoId))
                .ForMember(r => r.PerfilRelacionado, x => x.MapFrom(c => c.Curso.PerfilRelacionado == null ? "" : c.Curso.PerfilRelacionado.Nombre))
                .ForMember(r => r.Dias, x => x.MapFrom(c => c.Curso.Dias))
                .ForMember(r => r.Horas, x => x.MapFrom(c => c.Curso.Horas))
                .ForMember(r => r.ProvinciaId, x => x.MapFrom(c => c.Ubigeo.Provincia.ProvinciaId))
                .ForMember(r => r.Provincia, x => x.MapFrom(c => c.Ubigeo.Provincia.Nombre))
                .ForMember(r => r.DepartamentoId, x => x.MapFrom(c => c.Ubigeo.Departamento.DepartamentoId))
                .ForMember(r => r.Departamento, x => x.MapFrom(c => c.Ubigeo.Departamento.Nombre))
                .ForMember(r => r.TipoCapacitacionId, x => x.MapFrom(c => c.TipoCapacitacionId))
                .ForMember(r => r.TipoCapacitacion, x => x.MapFrom(c => c.TipoCapacitacion.Nombre))
                .ForMember(r => r.FacilitadorId, x => x.MapFrom(c => c.FacilitadorId))
                .ForMember(r => r.Facilitador, x => x.MapFrom(c => c.Facilitador == null ? "" : 
                    string.Concat(c.Facilitador.Nombres, " ", c.Facilitador.ApellidoPaterno, " ", c.Facilitador.ApellidoMaterno)))
                .ForMember(r => r.GestorId, x => x.MapFrom(c => c.GestorId))
                .ForMember(r => r.Gestor, x => x.MapFrom(c => c.Gestor == null ? "" : 
                    string.Concat(c.Gestor.Nombres, " ", c.Gestor.ApellidoPaterno, " ", c.Gestor.ApellidoMaterno)))
                .ForMember(r => r.Curso, x => x.MapFrom(c => c.Curso.Nombre))
                .ForMember(r => r.Documentacion, x => x.MapFrom(c => c.Documentaciones.Any(d => d.Activo) ? 
                    new Documentacion_O_DTO
                    {
                        DocumentacionId = c.Documentaciones.First(d => d.Activo).DocumentacionId, 
                        ArchivoOsFacilitador = string.IsNullOrEmpty(c.Documentaciones.First(d => d.Activo).OsFacilitador) || c.Documentaciones.First(d => d.Activo).OsFacilitador == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.Documentaciones.First(d => d.Activo).OsFacilitador)),
                        ArchivoTdrFacilitador = string.IsNullOrEmpty(c.Documentaciones.First(d => d.Activo).TdrFacilitador) || c.Documentaciones.First(d => d.Activo).TdrFacilitador == "null"  ? null : Convert.ToBase64String(File.ReadAllBytes(c.Documentaciones.First(d => d.Activo).TdrFacilitador)),
                        ArchivoTdrGestor = string.IsNullOrEmpty(c.Documentaciones.First(d => d.Activo).TdrGestor) || c.Documentaciones.First(d => d.Activo).TdrGestor == "null"  ? null : Convert.ToBase64String(File.ReadAllBytes(c.Documentaciones.First(d => d.Activo).TdrGestor)),
                        ArchivoOsGestor = string.IsNullOrEmpty(c.Documentaciones.First(d => d.Activo).OsGestor) || c.Documentaciones.First(d => d.Activo).OsGestor == "null"  ? null : Convert.ToBase64String(File.ReadAllBytes(c.Documentaciones.First(d => d.Activo).OsGestor)),
                        RutaOsFacilitador = c.Documentaciones.First(d => d.Activo).OsFacilitador,
                        RutaTdrFacilitador = c.Documentaciones.First(d => d.Activo).TdrFacilitador,
                        RutaTdrGestor = c.Documentaciones.First(d => d.Activo).TdrGestor,
                        RutaOsGestor = c.Documentaciones.First(d => d.Activo).OsGestor
                    } : new Documentacion_O_DTO() ))
                .ForMember(r => r.MaterialAcademico, x => x.MapFrom(c => c.MaterialesAcademicos.Any(d => d.Activo) ? 
                    new MaterialAcademico_O_DTO
                    {
                        MaterialAcademicoId = c.MaterialesAcademicos.First(d => d.Activo).MaterialAcademicoId, 
                        ArchivoFichaParticipante = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).FichaParticipante) || c.MaterialesAcademicos.First(d => d.Activo).FichaParticipante == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).FichaParticipante)),
                        ArchivoFichaEmpresa = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).FichaEmpresa) || c.MaterialesAcademicos.First(d => d.Activo).FichaEmpresa == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).FichaEmpresa)),
                        ArchivoGesInstructivos = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).GesInstructivos) || c.MaterialesAcademicos.First(d => d.Activo).GesInstructivos == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).GesInstructivos)),
                        ArchivoGesFormatoInforme = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).GesFormatoInforme) || c.MaterialesAcademicos.First(d => d.Activo).GesFormatoInforme == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).GesFormatoInforme)),
                        ArchivoSillabus = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).Sillabus) || c.MaterialesAcademicos.First(d => d.Activo).Sillabus == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).Sillabus)),
                        ArchivoPpt = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).Ppt) || c.MaterialesAcademicos.First(d => d.Activo).Ppt == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).Ppt)),
                        ArchivoEvaluaciones = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).Evaluaciones) || c.MaterialesAcademicos.First(d => d.Activo).Evaluaciones == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).Evaluaciones)),
                        ArchivoFacInstructivos = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).FacInstructivos) || c.MaterialesAcademicos.First(d => d.Activo).FacInstructivos == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).FacInstructivos)),
                        ArchivoFacFormatoInforme = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).FacFormatoInforme) || c.MaterialesAcademicos.First(d => d.Activo).FacFormatoInforme == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).FacFormatoInforme)),
                        ArchivoFichaAsistencia = string.IsNullOrEmpty(c.MaterialesAcademicos.First(d => d.Activo).FichaAsistencia) || c.MaterialesAcademicos.First(d => d.Activo).FichaAsistencia == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).FichaAsistencia)),
                        RutaFichaParticipante = c.MaterialesAcademicos.First(d => d.Activo).FichaParticipante,
                        RutaFichaEmpresa = c.MaterialesAcademicos.First(d => d.Activo).FichaEmpresa,
                        RutaGesInstructivos = c.MaterialesAcademicos.First(d => d.Activo).GesInstructivos,
                        RutaGesFormatoInforme = c.MaterialesAcademicos.First(d => d.Activo).GesFormatoInforme,
                        RutaSillabus = c.MaterialesAcademicos.First(d => d.Activo).Sillabus,
                        RutaPpt = c.MaterialesAcademicos.First(d => d.Activo).Ppt,
                        RutaEvaluaciones = c.MaterialesAcademicos.First(d => d.Activo).Evaluaciones,
                        RutaFacInstructivos = c.MaterialesAcademicos.First(d => d.Activo).FacInstructivos,
                        RutaFacFormatoInforme = c.MaterialesAcademicos.First(d => d.Activo).FacFormatoInforme,
                        RutaFichaAsistencia = c.MaterialesAcademicos.First(d => d.Activo).FichaAsistencia
                    } : new MaterialAcademico_O_DTO() )); // Lee
            
            //Documentacion
            CreateMap<Documentacion_I_DTO, Documentacion>();
            //MaterialAcademico
            CreateMap<MaterialAcademico_I_DTO, MaterialAcademico>();
            //PerfilRelacionado
            CreateMap<PerfilRelacionado, PerfilRelacionado_C_DTO>();
            //Participante
            CreateMap<Participante_I_DTO, Participante>()
                .ForMember(r => r.Usuario, x => x.MapFrom(c => c.CorreoElectronico))
                .ForMember(r => r.Contrasena, x => x.MapFrom(c => c.NumeroDocumento));
            CreateMap<Participante, Participante_O_DTO>()
                .ForMember(r => r.TipoDocumento, x => x.MapFrom(c => c.TipoDocumento != null ? c.TipoDocumento.Nombre : ""))
                .ForMember(r => r.Departamento, x => x.MapFrom(c => c.Departamento != null ? c.Departamento.Nombre : ""))
                .ForMember(r => r.PerfilRelacionado, x => x.MapFrom(c => c.PerfilRelacionado != null ? c.PerfilRelacionado.Nombre : ""))
                .ForMember(r => r.Sexo, x => x.MapFrom(c => c.Sexo != null ? c.Sexo.Nombre : ""))
                .ForMember(r => r.EstadoCivil, x => x.MapFrom(c => c.EstadoCivil != null ? c.EstadoCivil.Nombre : ""))
                .ForMember(r => r.NivelEducativo, x => x.MapFrom(c => c.NivelEducativo != null ? c.NivelEducativo.Nombre : ""))
                .ForMember(r => r.Alcance, x => x.MapFrom(c => c.Alcance != null ? c.Alcance.Nombre : ""))
                .ForMember(r => r.CargoOperativo, x => x.MapFrom(c => c.CargoOperativo != null ? c.CargoOperativo.Nombre : ""))
                .ForMember(r => r.CargoDirectivo, x => x.MapFrom(c => c.CargoDirectivo != null ? c.CargoDirectivo.Nombre : ""))
                .ForMember(r => r.TipoRemuneracion, x => x.MapFrom(c => c.TipoRemuneracion != null ? c.TipoRemuneracion.Nombre : ""))
                .ForMember(r => r.Provincia, x => x.MapFrom(c => c.Provincia != null ? c.Provincia.Nombre : ""))
                .ForMember(r => r.Distrito, x => x.MapFrom(c => c.Distrito != null ? c.Distrito.Nombre : ""))
                .ForMember(r => r.PerfilRelacionado, x => x.MapFrom(c => c.PerfilRelacionado != null ? c.PerfilRelacionado.Nombre : ""))
                .ForMember(r => r.ArchivoCertificadoEstudios, x => x.MapFrom(c => string.IsNullOrEmpty(c.CertificadoEstudios) || c.CertificadoEstudios == "null"  ? null : Convert.ToBase64String(File.ReadAllBytes(c.CertificadoEstudios))))
                .ForMember(r => r.ArchivoCertificadoTrabajo, x => x.MapFrom(c => string.IsNullOrEmpty(c.CertificadoTrabajo) || c.CertificadoTrabajo == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.CertificadoTrabajo))))
                .ForMember(r => r.RutaCertificadoEstudios, x => x.MapFrom(c => c.CertificadoEstudios))
                .ForMember(r => r.RutaCertificadoTrabajo, x => x.MapFrom(c => c.CertificadoTrabajo))
                .ForMember(r => r.ArchivoCertificadoTrabajo, x => x.MapFrom(c => string.IsNullOrEmpty(c.CertificadoTrabajo) || c.CertificadoTrabajo == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.CertificadoTrabajo))));
            CreateMap<Participante, ParticipantePostulado_O_DTO>()
                .ForMember(r => r.Ruc, x => x.MapFrom(c => c.EmpresaId.HasValue ? c.Empresa.Ruc : ""))
                .ForMember(r => r.TipoDocumento, x => x.MapFrom(c => c.TipoDocumento != null ? c.TipoDocumento.Nombre : ""))
                .ForMember(r => r.Departamento, x => x.MapFrom(c => c.Departamento != null ? c.Departamento.Nombre : ""))
                .ForMember(r => r.PerfilRelacionado, x => x.MapFrom(c => c.PerfilRelacionado != null ? c.PerfilRelacionado.Nombre : ""))
                .ForMember(r => r.Sexo, x => x.MapFrom(c => c.Sexo != null ? c.Sexo.Nombre : ""))
                .ForMember(r => r.EstadoCivil, x => x.MapFrom(c => c.EstadoCivil != null ? c.EstadoCivil.Nombre : ""))
                .ForMember(r => r.NivelEducativo, x => x.MapFrom(c => c.NivelEducativo != null ? c.NivelEducativo.Nombre : ""))
                .ForMember(r => r.Alcance, x => x.MapFrom(c => c.Alcance != null ? c.Alcance.Nombre : ""))
                .ForMember(r => r.CargoOperativo, x => x.MapFrom(c => c.CargoOperativo != null ? c.CargoOperativo.Nombre : ""))
                .ForMember(r => r.CargoDirectivo, x => x.MapFrom(c => c.CargoDirectivo != null ? c.CargoDirectivo.Nombre : ""))
                .ForMember(r => r.TipoRemuneracion, x => x.MapFrom(c => c.TipoRemuneracion != null ? c.TipoRemuneracion.Nombre : ""))
                .ForMember(r => r.Provincia, x => x.MapFrom(c => c.Provincia != null ? c.Provincia.Nombre : ""))
                .ForMember(r => r.Distrito, x => x.MapFrom(c => c.Distrito != null ? c.Distrito.Nombre : ""))
                .ForMember(r => r.PerfilRelacionado, x => x.MapFrom(c => c.PerfilRelacionado != null ? c.PerfilRelacionado.Nombre : ""))
                .ForMember(r => r.ArchivoCertificadoEstudios, x => x.MapFrom(c => string.IsNullOrEmpty(c.CertificadoEstudios) || c.CertificadoEstudios == "null"  ? null : Convert.ToBase64String(File.ReadAllBytes(c.CertificadoEstudios))))
                .ForMember(r => r.ArchivoCertificadoTrabajo, x => x.MapFrom(c => string.IsNullOrEmpty(c.CertificadoTrabajo) || c.CertificadoTrabajo == "null" ? null : Convert.ToBase64String(File.ReadAllBytes(c.CertificadoTrabajo))))
                .ForMember(r => r.RutaCertificadoEstudios, x => x.MapFrom(c => c.CertificadoEstudios))
                .ForMember(r => r.RutaCertificadoTrabajo, x => x.MapFrom(c => c.CertificadoTrabajo))
                .ForMember(r => r.EstadoCapacitacion, x => x.MapFrom(c => c.ParticipanteCapacitacion.Any() ? c.ParticipanteCapacitacion.First().Estado : ""));

            CreateMap<Capacitacion, RegistroPostulacion_O_DTO>()
                .ForMember(r => r.NombreCurso, x => x.MapFrom(c => c.Curso.Nombre))
                .ForMember(r => r.Horas, x => x.MapFrom(c => c.Curso.Horas))
                .ForMember(r => r.HorasMinimas, x => x.MapFrom(c => c.Curso.HorasAprobar))
                .ForMember(r => r.Facilitador,
                    x => x.MapFrom(c =>
                        c.Facilitador != null
                            ? string.Concat(c.Facilitador.Nombres, " ", c.Facilitador.ApellidoPaterno, " ",
                                c.Facilitador.ApellidoMaterno).ToUpper()
                            : ""))
                .ForMember(r => r.Estado, x => x.MapFrom(c => "Activo"))
                .ForMember(r => r.TipoCapacitacionId, x => x.MapFrom(c => c.TipoCapacitacionId))
                .ForMember(r => r.TipoCapacitacion, x => x.MapFrom(c => c.TipoCapacitacion.Nombre))
                .ForMember(r => r.HorasMinimas, x => x.MapFrom(c => c.Curso.HorasAprobar))
                .ForMember(r => r.Final, x => x.MapFrom(c => c.Curso.Final))
                .ForMember(r => r.Practica, x => x.MapFrom(c => c.Curso.Practica))
                .ForMember(r => r.PracticaNoAplica, x => x.MapFrom(c => c.Curso.PracticaNoAplica))
                .ForMember(r => r.Practica2, x => x.MapFrom(c => c.Curso.Practica2))
                .ForMember(r => r.PracticaNoAplica2, x => x.MapFrom(c => c.Curso.PracticaNoAplica2))
                .ForMember(r => r.Practica3, x => x.MapFrom(c => c.Curso.Practica3))
                .ForMember(r => r.PracticaNoAplica3, x => x.MapFrom(c => c.Curso.PracticaNoAplica3))
                .ForMember(r => r.Practica4, x => x.MapFrom(c => c.Curso.Practica4))
                .ForMember(r => r.PracticaNoAplica4, x => x.MapFrom(c => c.Curso.PracticaNoAplica4))
                .ForMember(r => r.Practica5, x => x.MapFrom(c => c.Curso.Practica5))
                .ForMember(r => r.PracticaNoAplica5, x => x.MapFrom(c => c.Curso.PracticaNoAplica5))
                .ForMember(r => r.DesempenioNoAplica, x => x.MapFrom(c => c.Curso.DesempenioNoAplica))
                .ForMember(r => r.FinalNoAplica, x => x.MapFrom(c => c.Curso.FinalNoAplica))
                //.ForMember(r => r.PostuladoAceptado, x => x.MapFrom(c => c.ParticipanteCapacitacion.Any(p => p.Estado == "P" || p.Estado == "A") ? true : false))
                .ForMember(r => r.PracticaTotal, x => x.MapFrom(c => c.Curso.Practica ?? 0 + c.Curso.Practica2 ?? 0 + c.Curso.Practica3 ?? 0 + c.Curso.Practica4 ?? 0 + c.Curso.Practica5));
            //Empresa
            CreateMap<Empresa_I_DTO, Empresa>()
                .ForMember(r => r.WebInscrita, x => x.MapFrom(c => string.Join(",",c.WebInscrita)));
            CreateMap<Empresa, Empresa_O_DTO>()
                .ForMember(r => r.Rubro, x => x.MapFrom(c => c.Rubro != null ? c.Rubro.Nombre : ""))
                .ForMember(r => r.Dicertur, x => x.MapFrom(c => c.Dicertur != null ? c.Dicertur.Nombre : ""))
                .ForMember(r => r.Clase, x => x.MapFrom(c => c.Clase != null ? c.Clase.Nombre : ""))
                .ForMember(r => r.Categoria, x => x.MapFrom(c => c.Categoria != null ? c.Categoria.Nombre : ""))
                .ForMember(r => r.Departamento, x => x.MapFrom(c => c.Departamento != null ? c.Departamento.Nombre : ""))
                .ForMember(r => r.Provincia, x => x.MapFrom(c => c.Provincia != null ? c.Provincia.Nombre : ""))
                .ForMember(r => r.Distrito, x => x.MapFrom(c => c.Distrito != null ? c.Distrito.Nombre : ""))
                .ForMember(r => r.TipoContribuyente, x => x.MapFrom(c => c.TipoContribuyente != null ? c.TipoContribuyente.Nombre : ""))
                .ForMember(r => r.WebInscrita, x => x.MapFrom(c => c.WebInscrita.Split(",", StringSplitOptions.None)));
            
            //ParticipanteCapacitacion
            
            //EncuestaSatisfaccion
            CreateMap<RegistroEncuentra_I_DTO, EncuestaSatisfaccion>()
                .ForMember(r => r.FechaCreacion, x => x.MapFrom(c => DateTime.Now));
            
            //Notas
            CreateMap<Nota, Nota_O_DTO>()
                .ForMember(r => r.NumeroDocumento, x => x.MapFrom(c => c.Participante.NumeroDocumento))
                .ForMember(r => r.Participante, x => x.MapFrom(c => string.Concat(c.Participante.ApellidoPaterno, " ", c.Participante.ApellidoMaterno, ", ", c.Participante.Nombres)));
            
            //EncuestaSatisfaccion
            CreateMap<FichaSupervision_I_DTO, FichaSupervision>()
                .ForMember(r => r.Resultado, x => x.MapFrom(c => c.Calificacion <= 5 ? "MALO" : c.Calificacion <= 10 ? "DEFICIENTE" : c.Calificacion <= 14 ? "REGULAR": c.Calificacion <= 18 ? "BUENO" : "EXCELENTE"));
            CreateMap<FichaSupervision, FichaSupervision_O_DTO>()
                .ForMember(r => r.FechaSupervision, x => x.MapFrom(c => c.FechaSupervision.HasValue ? c.FechaSupervision.Value.ToString("yyyy-MM-dd") : ""))
                .ForMember(r => r.Curso, x => x.MapFrom(c => c.Capacitacion != null ? c.Capacitacion.Curso.Nombre : ""))
                .ForMember(r => r.Programa, x => x.MapFrom(c => c.Programa != null ? c.Programa.Nombre : ""))
                .ForMember(r => r.Departamento,
                    x => x.MapFrom(c => c.Departamento != null ? c.Departamento.Nombre : ""))
                .ForMember(r => r.Supervisor,
                    x => x.MapFrom(c =>
                        c.Supervisor == null
                            ? ""
                            : string.Concat(c.Supervisor.Nombres, " ", c.Supervisor.ApellidoPaterno, " ",
                                c.Supervisor.ApellidoMaterno)))
                .ForMember(r => r.Facilitador,
                    x => x.MapFrom(c =>
                        c.Facilitador == null
                            ? ""
                            : string.Concat(c.Facilitador.Nombres, " ", c.Facilitador.ApellidoPaterno, " ",
                                c.Facilitador.ApellidoMaterno)))
                .ForMember(r => r.TipoSupervision,
                    x => x.MapFrom(c => c.TipoSupervision != null ? c.TipoSupervision.Nombre : ""));
            
            //Directorio Encuesta
            CreateMap<DirectorioEncuesta, DirectorioEncuesta_O_DTO>()
                .ForMember(r => r.Distrito, x => x.MapFrom(c => c.Distrito.Nombre))
                .ForMember(r => r.Departamento, x => x.MapFrom(c => c.Distrito.Departamento.Nombre))
                .ForMember(r => r.Provincia, x => x.MapFrom(c => c.Distrito.Provincia.Nombre))
                .ForMember(r => r.DepartamentoId, x => x.MapFrom(c => c.Distrito.Departamento.DepartamentoId))
                .ForMember(r => r.ProvinciaId, x => x.MapFrom(c => c.Distrito.Provincia.ProvinciaId));
            CreateMap<DirectorioEncuesta_I_DTO, DirectorioEncuesta>();

            CreateMap<Capacitacion, CapacitacionPFC_O_DTO>()
                .ForMember(r => r.TipoCapacitacion, x => x.MapFrom(c => c.TipoCapacitacion == null ? "" : c.TipoCapacitacion.Nombre))
                .ForMember(r => r.Departamento, x => x.MapFrom(c => c.Ubigeo == null ? "" : c.Ubigeo.Departamento.Nombre))
                .ForMember(r => r.Provincia, x => x.MapFrom(c => c.Ubigeo == null ? "" : c.Ubigeo.Provincia.Nombre))
                .ForMember(r => r.Distrito, x => x.MapFrom(c => c.Ubigeo == null ? "" : c.Ubigeo.Nombre))
                .ForMember(r => r.Curso, x => x.MapFrom(c => c.Curso == null ? "" :  c.Curso.Nombre))
                .ForMember(r => r.Horas, x => x.MapFrom(c => c.Curso == null ? 0 : c.Curso.Horas))
                .ForMember(r => r.Sesiones,
                    x => x.MapFrom(c => (c.FechaFin - c.FechaInicio).TotalDays))
                .ForMember(r => r.FechaInicio, x => x.MapFrom(c => c.FechaInicio))
                .ForMember(r => r.FechaFin, x => x.MapFrom(c => c.FechaFin))
                .ForMember(r => r.Gestor, x => x.MapFrom(c => c.GestorId.HasValue
                    ? string.Concat(c.Gestor.ApellidoPaterno, " ", c.Gestor.ApellidoMaterno,
                        ", ", c.Gestor.Nombres)
                    : ""))
                .ForMember(r => r.Facilitador, x => x.MapFrom(c => c.FacilitadorId.HasValue
                    ? string.Concat(c.Facilitador.ApellidoPaterno, " ",
                        c.Facilitador.ApellidoMaterno,
                        ", ", c.Facilitador.Nombres)
                    : ""));
            
            CreateMap<ProgramacionInfoPFC_I_DTO, ProgramacionInfoPFC>()
                .ForMember(r => r.TotalCostoFacilitador, x => x.MapFrom(c => c.Honorarios ?? 0 + c.Viaticos ?? 0 + c.Pasajes ?? 0));
            
            CreateMap<ProgramacionInfoPFC, ProgramacionInfoPFC_O_DTO>()
                .ForMember(r => r.TipoCapacitacion, x => x.MapFrom(c => c.Capacitacion.TipoCapacitacion == null ? "" : c.Capacitacion.TipoCapacitacion.Nombre))
                .ForMember(r => r.Departamento, x => x.MapFrom(c => c.Capacitacion.Ubigeo == null ? "" : c.Capacitacion.Ubigeo.Departamento.Nombre))
                .ForMember(r => r.Provincia, x => x.MapFrom(c => c.Capacitacion.Ubigeo == null ? "" : c.Capacitacion.Ubigeo.Provincia.Nombre))
                .ForMember(r => r.Distrito, x => x.MapFrom(c => c.Capacitacion.Ubigeo == null ? "" : c.Capacitacion.Ubigeo.Nombre))
                .ForMember(r => r.Curso, x => x.MapFrom(c => c.Capacitacion.Curso == null ? "" :  c.Capacitacion.Curso.Nombre))
                .ForMember(r => r.Horas, x => x.MapFrom(c => c.Capacitacion.Curso == null ? 0 : c.Capacitacion.Curso.Horas))
                .ForMember(r => r.Sesiones,
                    x => x.MapFrom(c => (c.Capacitacion.FechaFin - c.Capacitacion.FechaInicio).TotalDays))
                .ForMember(r => r.FechaInicio, x => x.MapFrom(c => c.Capacitacion.FechaInicio))
                .ForMember(r => r.FechaFin, x => x.MapFrom(c => c.Capacitacion.FechaFin))
                .ForMember(r => r.Gestor, x => x.MapFrom(c => c.Capacitacion.GestorId.HasValue
                    ? string.Concat(c.Capacitacion.Gestor.ApellidoPaterno, " ", c.Capacitacion.Gestor.ApellidoMaterno,
                        ", ", c.Capacitacion.Gestor.Nombres)
                    : ""))
                .ForMember(r => r.Facilitador, x => x.MapFrom(c => c.Capacitacion.FacilitadorId.HasValue
                    ? string.Concat(c.Capacitacion.Facilitador.ApellidoPaterno, " ",
                        c.Capacitacion.Facilitador.ApellidoMaterno,
                        ", ", c.Capacitacion.Facilitador.Nombres)
                    : ""));
        }


        private List<RolSubModulo_O_DTO> MapModuloDTORolSubModulo(Modulo _Modulo, Modulo_O_DTO _Modulo_O_DTO)
        {
            var resultado = new List<RolSubModulo_O_DTO>();

            if (_Modulo.SubModulos == null) { return resultado; };


            foreach (var SubModulo in _Modulo.SubModulos)
            {
                resultado.Add(new RolSubModulo_O_DTO()
                {
                    RolSubModuloId = SubModulo.RolSubModulo.RolSubModuloId,
                    RolId = SubModulo.RolSubModulo.RolId,
                    SubModuloId = SubModulo.RolSubModulo.SubModuloId,

                    SubModuloNombre  = SubModulo.Nombre,
                    SubModuloRuta = SubModulo.Ruta,

                    Ver = SubModulo.RolSubModulo.Ver,
                    Agregar = SubModulo.RolSubModulo.Agregar,
                    Editar = SubModulo.RolSubModulo.Editar,
                    Eliminar = SubModulo.RolSubModulo.Eliminar,
                    UsuarioCreacionId = SubModulo.RolSubModulo.UsuarioCreacionId,
                    UsuarioModificacionId = SubModulo.RolSubModulo.UsuarioModificacionId,
                    FechaCreacion = SubModulo.RolSubModulo.FechaCreacion,
                    FechaModificacion = SubModulo.RolSubModulo.FechaModificacion,
                    Activo = SubModulo.RolSubModulo.Activo
                });
            }

            return resultado;
        }


        //private List<RolSubModulo_O_DTO> MapSubModuloDTORolSubModulo(SubModulo _SubModulo, SubModulo_O_DTO _SubModulo_O_DTO)
        //{
        //    var resultado = new List<RolSubModulo_O_DTO>();

        //    if (_SubModulo.RolSubModulo == null) { return resultado; };


        //    foreach (var RolSubModulo in _SubModulo.RolSubModulo)
        //    {
        //        resultado.Add(new RolSubModulo_O_DTO()
        //        {
        //            RolSubModuloId = RolSubModulo.RolSubModuloId,
        //            RolId = RolSubModulo.RolId,
        //            SubModuloId = RolSubModulo.SubModuloId,
        //            Ver = RolSubModulo.Ver,
        //            Agregar = RolSubModulo.Agregar,
        //            Editar = RolSubModulo.Editar,
        //            Eliminar = RolSubModulo.Eliminar,
        //            UsuarioCreacionId = RolSubModulo.UsuarioCreacionId,
        //            UsuarioModificacionId = RolSubModulo.UsuarioModificacionId,
        //            FechaCreacion = RolSubModulo.FechaCreacion,
        //            FechaModificacion = RolSubModulo.FechaModificacion,
        //            Activo = RolSubModulo.Activo
        //        });
        //    }

        //    return resultado;
        //}




    }
}
