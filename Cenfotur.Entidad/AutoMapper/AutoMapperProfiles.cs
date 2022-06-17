using AutoMapper;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Models;
using System;
using System.Collections.Generic;
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
                .ForMember(r => r.RolId, x => x.MapFrom(c => c.EmpleadoRol.FirstOrDefault() == null ? 0 : c.EmpleadoRol.First().RolId)); // Lee

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
