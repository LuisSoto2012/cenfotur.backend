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
            CreateMap<Curso, Curso_O_DTO>(); // Lee
            
            
            //Comunes
            CreateMap<Departamento, Departamento_O_DTO>();
            CreateMap<Provincia, Provincia_O_DTO>();
            CreateMap<Distrito, Distrito_O_DTO>();
            CreateMap<TipoCapacitacion, TipoCapacitacion_O_DTO>();
            CreateMap<Empleado, Facilitador_O_DTO>()
                .ForMember(r => r.FacilitadorId, x => x.MapFrom(e => e.EmpleadoId))
                .ForMember(r => r.Nombre, x => x.MapFrom(e => string.Concat(e.Nombres, " ", e.ApellidoPaterno, " ", e.ApellidoMaterno).ToUpper()));
            CreateMap<Empleado, Gestor_O_DTO>()
                .ForMember(r => r.GestorId, x => x.MapFrom(e => e.EmpleadoId))
                .ForMember(r => r.Nombre, x => x.MapFrom(e => string.Concat(e.Nombres, " ", e.ApellidoPaterno, " ", e.ApellidoMaterno).ToUpper()));
            CreateMap<Curso, Curso_C_DTO>();
            
            //Capacitaciones
            CreateMap<Capacitacion_I_DTO, Capacitacion>()
                .ForMember(r => r.UbigueoId, x => x.MapFrom(c => c.DistritoId)); // Inserta
            CreateMap<Capacitacion, Capacitacion_O_DTO>()
                .ForMember(r => r.DistritoId, x => x.MapFrom(c => c.UbigueoId))
                .ForMember(r => r.Distrito, x => x.MapFrom(c => c.Ubigeo.Nombre))
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
                        ArchivoOsFacilitador = c.Documentaciones.First(d => d.Activo).OsFacilitador == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.Documentaciones.First(d => d.Activo).OsFacilitador)),
                        ArchivoTdrFacilitador = c.Documentaciones.First(d => d.Activo).TdrFacilitador == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.Documentaciones.First(d => d.Activo).TdrFacilitador)),
                        ArchivoTdrGestor = c.Documentaciones.First(d => d.Activo).TdrGestor == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.Documentaciones.First(d => d.Activo).TdrGestor)),
                        ArchivoOsGestor = c.Documentaciones.First(d => d.Activo).OsGestor == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.Documentaciones.First(d => d.Activo).OsGestor))
                    } : new Documentacion_O_DTO() ))
                .ForMember(r => r.MaterialAcademico, x => x.MapFrom(c => c.MaterialesAcademicos.Any(d => d.Activo) ? 
                    new MaterialAcademico_O_DTO
                    {
                        MaterialAcademicoId = c.MaterialesAcademicos.First(d => d.Activo).MaterialAcademicoId, 
                        ArchivoFichaParticipante = c.MaterialesAcademicos.First(d => d.Activo).FichaParticipante == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).FichaParticipante)),
                        ArchivoFichaEmpresa = c.MaterialesAcademicos.First(d => d.Activo).FichaEmpresa == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).FichaEmpresa)),
                        ArchivoGesInstructivos = c.MaterialesAcademicos.First(d => d.Activo).GesInstructivos == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).GesInstructivos)),
                        ArchivoGesFormatoInforme = c.MaterialesAcademicos.First(d => d.Activo).GesFormatoInforme == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).GesFormatoInforme)),
                        ArchivoSillabus = c.MaterialesAcademicos.First(d => d.Activo).Sillabus == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).Sillabus)),
                        ArchivoPpt = c.MaterialesAcademicos.First(d => d.Activo).Ppt == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).Ppt)),
                        ArchivoEvaluaciones = c.MaterialesAcademicos.First(d => d.Activo).Evaluaciones == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).Evaluaciones)),
                        ArchivoFacInstructivos = c.MaterialesAcademicos.First(d => d.Activo).FacInstructivos == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).FacInstructivos)),
                        ArchivoFacFormatoInforme = c.MaterialesAcademicos.First(d => d.Activo).FacFormatoInforme == null ? null : Convert.ToBase64String(File.ReadAllBytes(c.MaterialesAcademicos.First(d => d.Activo).FacFormatoInforme))
                    } : new MaterialAcademico_O_DTO() )); // Lee
            
            //Documentacion
            CreateMap<Documentacion_I_DTO, Documentacion>();
            //MaterialAcademico
            CreateMap<MaterialAcademico_I_DTO, MaterialAcademico>();
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
