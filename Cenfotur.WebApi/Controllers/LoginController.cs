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
                return BadRequest("Revisar sus credenciales");
            }


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
            //var prueba = Roles_Empleado;
            //List<int> Roles_Empleado = new List<int>() { 1 };

            var Roles = _Mapper.Map<List<Rol_O_DTO>>(_Context.Roles.Where(e => Roles_Empleado.Contains(e.RolId)).ToList());
            // ------------------------- Fin Seccion Roles -------------------------



            // ------------------------- Inicio Seccion Modulos -------------------------
            var ListaModulosdelEmpleado = _Context.RolSubModulo.Include(sm => sm.SubModulo).Where(rsm => Roles_Empleado.Contains(rsm.RolId)).Select(e => e.SubModulo.ModuloId).ToList();
            //var ListaModulosdelEmpleado = _Context.RolSubModulo.Include(sm => sm.SubModulo).Where(rsm => Roles_Empleado.Contains(rsm.RolId)).GroupBy(g=>g.RolId).Select(g => new { count = g.Count() }).ToList();
            //var ListaModulosdelEmpleado = _Context.RolSubModulo.Where(rsm => Roles_Empleado.Contains(rsm.RolId)).Select(e => e.R).ToList();
            if (ListaModulosdelEmpleado == null)
            {
                return BadRequest("No se le ha asignado Modulos al usuario");
            }

            List<int> Modulos_Empleado = new List<int>();
            foreach (var m in ListaModulosdelEmpleado)
            {
                Modulos_Empleado.Add(m);
            }

            //var asasa = _Context.Modulos.Include(sm => sm.SubModulos).ThenInclude(rsm => rsm.RolSubModulo).Where(m => Modulos_Empleado.Contains(m.ModuloId)).ToList();
            //var oooo = _Context.Modulos.Include(sm => sm.SubModulos).ThenInclude(rsm=>rsm.RolSubModulo).Where(m => Modulos_Empleado.Contains(m.ModuloId)).ToList();
            //var Modulos = _Mapper.Map<List<Modulo_O_DTO>>(_Context.Modulos.Include(sm => sm.SubModulos).Where(m => m.ModuloId == 1).ToList());
            var Modulos = _Mapper.Map<List<Modulo_O_DTO>>(_Context.Modulos.Include(sm => sm.SubModulos).ThenInclude(rsm => rsm.RolSubModulo).Where(m => Modulos_Empleado.Contains(m.ModuloId)).ToList());

            

            // ------------------------- Fin Seccion Modulos -------------------------




            return new OkObjectResult(new
            {
                EmpleadoId = Persona.EmpleadoId,
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


        }
    }
}
