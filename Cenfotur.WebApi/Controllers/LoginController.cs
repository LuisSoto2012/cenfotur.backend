using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Output;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cenfotur.WebApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        public LoginController(ApplicationDbContext context, IMapper mapper)
        {
            this._Context = context;
            this._Mapper = mapper;
        }
        [HttpGet] //api/login
        public async Task<ActionResult<List<Login_O_DTO>>> Get(string Usuario, string Contrasena)
        {
            var Persona = await _Context.Empleados.FirstOrDefaultAsync(e => e.Usuario == Usuario && e.Contrasena == Contrasena);
            if (Persona==null)
            {
                //Validar si es participante
                var participante =
                    await _Context.Participantes.FirstOrDefaultAsync(p =>
                        p.Usuario == Usuario && p.Contrasena == Contrasena);
                if (participante == null)
                {
                    return BadRequest("Revisar sus credenciales");    
                }

                #region Permisos Participante

                var Roles = _Mapper.Map<List<Rol_O_DTO>>(_Context.Roles.Where(e => e.Nombre.ToUpper() == "PARTICIPANTE").ToList());
                // ------------------------- Fin Seccion Roles -------------------------

                // ------------------------- Inicio Seccion Modulos -------------------------
                var ListaModulosdelParticipante = _Context.RolSubModulo.Include(sm => sm.SubModulo).Where(rsm => rsm.RolId == Roles.First().RolId).Select(e => e.SubModulo.ModuloId).ToList();
                if (ListaModulosdelParticipante == null)
                {
                    return BadRequest("No se le ha asignado Modulos al usuario");
                }

                List<int> Modulos_Participante = new List<int>();
                foreach (var m in ListaModulosdelParticipante)
                {
                    Modulos_Participante.Add(m);
                }
            
                var Modulos = _Mapper.Map<List<Modulo_O_DTO>>(_Context.Modulos.Include(sm => sm.SubModulos).ThenInclude(rsm => rsm.RolSubModulo).Where(m => Modulos_Participante.Contains(m.ModuloId)).ToList());

            

                // ------------------------- Fin Seccion Modulos -------------------------




                return new OkObjectResult(new
                {
                    EmpleadoId = 0,
                    ParticipanteId = participante.ParticipanteId,
                    EmpresaId = participante.EmpresaId ?? 0,
                    DepartamentoId = participante.DepartamentoId,
                    Usuario = participante.Usuario,
                    Nombres = participante.Nombres,
                    ApePaterno = participante.ApellidoPaterno,
                    ApeMaterno = participante.ApellidoMaterno,
                    FechaNacimiento = participante.FechaNacimiento.HasValue ? participante.FechaNacimiento.Value.ToString("MM-dd") : "",
                    Token = "",
                    Success = true,
                    Message = "Bienvenido a CENFOTUR",

                    Roles,
                    Modulos

                });

                #endregion
            }
            else
            {
                #region Permisos Empleado

            // ------------------------- Inicio Seccion Roles -------------------------
            var ListaRolesdelEmpleado = _Context.EmpleadoRol.Where(er => er.EmpleadoId == Persona.EmpleadoId).Select(e => e.RolId).ToList();
            if (ListaRolesdelEmpleado == null)
            {
                return BadRequest("No se le ha asignado un rol al usuario");
            }

            List<int> Roles_Empleado = new List<int>();
            foreach(var r in ListaRolesdelEmpleado)
            {
                Roles_Empleado.Add(r);
            }

            var Roles = _Mapper.Map<List<Rol_O_DTO>>(_Context.Roles.Where(e => Roles_Empleado.Contains(e.RolId)).ToList());
            // ------------------------- Fin Seccion Roles -------------------------

            // ------------------------- Inicio Seccion Modulos -------------------------
            var ListaModulosdelEmpleado = _Context.RolSubModulo.Include(sm => sm.SubModulo).Where(rsm => Roles_Empleado.Contains(rsm.RolId)).Select(e => e.SubModulo.ModuloId).ToList();
            if (ListaModulosdelEmpleado == null)
            {
                return BadRequest("No se le ha asignado Modulos al usuario");
            }

            List<int> Modulos_Empleado = new List<int>();
            foreach (var m in ListaModulosdelEmpleado)
            {
                Modulos_Empleado.Add(m);
            }
            
            var Modulos = _Mapper.Map<List<Modulo_O_DTO>>(_Context.Modulos.Include(sm => sm.SubModulos).ThenInclude(rsm => rsm.RolSubModulo).Where(m => Modulos_Empleado.Contains(m.ModuloId)).ToList());

            

            // ------------------------- Fin Seccion Modulos -------------------------




            return new OkObjectResult(new
            {
                EmpleadoId = Persona.EmpleadoId,
                ParticipanteId = 0,
                Usuario = Persona.Usuario,
                Nombres = Persona.Nombres,
                ApePaterno = Persona.ApellidoPaterno,
                ApeMaterno = Persona.ApellidoMaterno,
                FechaNacimiento = Persona.FechaNacimiento.ToString("MM-dd"),
                Token = "",
                Success = true,
                Message = "Bienvenido a CENFOTUR",

                Roles,
                Modulos

            });

            #endregion
            }

        }
    }
}
