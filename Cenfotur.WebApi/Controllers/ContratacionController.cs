using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.DTOS.Output;
using Cenfotur.Entidad.Entidades.Contrataciones;
using Cenfotur.Entidad.Models;
using Cenfotur.Entidad.ViewModels;
using Cenfotur.Entidad.ViewModels.Contrataciones;
using Cenfotur.Negocio.Negocios.Contrataciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cenfotur.WebApi.Controllers
{
    [ApiController]
    [Route("api/contrataciones")]
    public class ContratacionController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IMapper _Mapper;
        private readonly ArchivoSettings _archivoSettings;

        public ContratacionController(ApplicationDbContext context, IMapper mapper, IOptions<ArchivoSettings> archivoSettings)
        {
            this._Context = context;
            this._Mapper = mapper;
            _archivoSettings = archivoSettings.Value ?? throw new ArgumentNullException(nameof(archivoSettings));
        }

        [HttpGet] // api/Contrataciones
        public List<ContratacionListado_E> Get(string Anio)
        {
            ContratacionListado_N obj = new();
            return obj.ListaContratacionListado(Anio);
        }

        [HttpGet("estadistica_1")]
        public List<ContratacionEstadistica_1_E> Estadistica_1(string Anio)
        {
            ContratacionEstadistica_1_N obj = new();
            return obj.ContratacionEstadistica_1(Anio);
        }


        [HttpPost("[action]")]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> NuevaContratacion([FromForm]EmpleadoContratacion_VM _EmpleadoContratacion_VM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // AsNoTracking() para evitar un error de instancia de entidad
            var ExisteEmpleado = await _Context.Empleados.AsNoTracking().FirstOrDefaultAsync(e => e.NumDoc == _EmpleadoContratacion_VM.NumDoc);

            // Obtiene el año
            var TablaAnio = await _Context.Anios.AsNoTracking().FirstOrDefaultAsync(a => a.Nombre == _EmpleadoContratacion_VM.AnioNombre);
            if (TablaAnio == null)
            {
                return BadRequest("Error con el año");
            }

        

            // --------- Empleado nuevo y nueva contratación ---------
            if (ExisteEmpleado == null)
            {

                Empleado _Empleado_1 = new Empleado()
                {
                    ApellidoPaterno = _EmpleadoContratacion_VM.ApellidoPaterno,
                    ApellidoMaterno = _EmpleadoContratacion_VM.ApellidoMaterno,
                    Nombres = _EmpleadoContratacion_VM.Nombres,
                    SexoId = _EmpleadoContratacion_VM.SexoId,
                    TelefMovil = _EmpleadoContratacion_VM.TelefMovil,
                    //Correo = _EmpleadoContratacion_VM.Correo,
                    FechaNacimiento = _EmpleadoContratacion_VM.FechaNacimiento,
                    TipoDocumentoId = _EmpleadoContratacion_VM.TipoDocumentoId,
                    NumDoc = _EmpleadoContratacion_VM.NumDoc,
                    Usuario = _EmpleadoContratacion_VM.NumDoc,
                    Contrasena = _EmpleadoContratacion_VM.NumDoc + _EmpleadoContratacion_VM.SexoId.ToString(),

                    FechaCreacion = DateTime.Now,
                    UsuarioCreacionId = _EmpleadoContratacion_VM.UsuarioCreacionId,
                    Activo = _EmpleadoContratacion_VM.Activo,
                };

                try
                {
                    _Context.Empleados.Add(_Empleado_1);
                    await _Context.SaveChangesAsync();

                    var var_EmpleadoId = _Empleado_1.EmpleadoId;

                    Contratacion _Contratacion_1 = new Contratacion()
                    {
                        AnioId = TablaAnio.AnioId, //lleno con el id capturado
                        EmpleadoId = var_EmpleadoId,
                        FechaContratacion = _EmpleadoContratacion_VM.FechaContratacion,
                        PuestoLaboralId = _EmpleadoContratacion_VM.PuestoLaboralId,
                        MetaPresupuestalId = _EmpleadoContratacion_VM.MetaPresupuestalId,
                        OrdenServicio = _EmpleadoContratacion_VM.OrdenServicio,
                        ContratacionDescripcion = _EmpleadoContratacion_VM.ContratacionDescripcion,
                        Remuneracion = _EmpleadoContratacion_VM.Remuneracion,

                        FechaCreacion = DateTime.Now,
                        UsuarioModificacionId = _EmpleadoContratacion_VM.UsuarioCreacionId,
                        Activo = _EmpleadoContratacion_VM.Activo,

                    };

                    // Carga de Archivo
                    
                    var ruta = @$"{_archivoSettings.Ruta}{_EmpleadoContratacion_VM.NumDoc}\";
                    if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);

                    if (_EmpleadoContratacion_VM.ArchivoOrdenServicio != null)
                    {
                        var archivoOrdenServicio = _EmpleadoContratacion_VM.ArchivoOrdenServicio;
                        var fullPath = string.Concat(ruta, archivoOrdenServicio.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await archivoOrdenServicio.CopyToAsync(fileStream);
                            _Contratacion_1.ArchivoOrdenServicio = fullPath;
                        }
                    }
                    
                    _Context.Contrataciones.Add(_Contratacion_1);
                    await _Context.SaveChangesAsync();

                }
                catch (Exception ex)
                {

                    return BadRequest(ex.ToString());
                }

                return Ok();


            }

            // --------- El mismo Empleado pero es una nueva contratación ---------
            else
            {

                try
                {

                    Contratacion _Contratacion_2 = new Contratacion()
                    {
                        AnioId = TablaAnio.AnioId, //lleno con el id capturado,
                        EmpleadoId = ExisteEmpleado.EmpleadoId, // Variable Recuperada
                        FechaContratacion = _EmpleadoContratacion_VM.FechaContratacion,
                        PuestoLaboralId = _EmpleadoContratacion_VM.PuestoLaboralId,
                        MetaPresupuestalId = _EmpleadoContratacion_VM.MetaPresupuestalId,
                        OrdenServicio = _EmpleadoContratacion_VM.OrdenServicio,
                        ContratacionDescripcion = _EmpleadoContratacion_VM.ContratacionDescripcion,
                        Remuneracion = _EmpleadoContratacion_VM.Remuneracion,

                        FechaCreacion = DateTime.Now,
                        UsuarioModificacionId = _EmpleadoContratacion_VM.UsuarioCreacionId,
                        Activo = _EmpleadoContratacion_VM.Activo,

                    };

                    // Carga de Archivo
                    
                    var ruta = @$"{_archivoSettings.Ruta}{_EmpleadoContratacion_VM.NumDoc}\";
                    if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                    
                    if (_EmpleadoContratacion_VM.ArchivoOrdenServicio != null)
                    {
                        var archivoOrdenServicio = _EmpleadoContratacion_VM.ArchivoOrdenServicio;
                        var fullPath = string.Concat(ruta, archivoOrdenServicio.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await archivoOrdenServicio.CopyToAsync(fileStream);
                            _Contratacion_2.ArchivoOrdenServicio = fullPath;
                        }
                    }
                    
                    _Context.Contrataciones.Add(_Contratacion_2);
                    await _Context.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.ToString());
                }

                return Ok();
            }

        }


        [HttpPut("[action]")]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> ActualizaContratacion([FromForm]EmpleadoContratacion_VM _EmpleadoContratacion_VM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_EmpleadoContratacion_VM.EmpleadoId < 1 || _EmpleadoContratacion_VM.ContratacionId < 1)
            {
                return BadRequest("El Id de empleado o Contratación estan errados");
            }

            // AsNoTracking() para evitar un error de instancia de entidad
            var ExisteContratacion = await _Context.Contrataciones.AsNoTracking().FirstOrDefaultAsync(e => e.EmpleadoId == _EmpleadoContratacion_VM.EmpleadoId && e.ContratacionId == _EmpleadoContratacion_VM.ContratacionId);
            if (ExisteContratacion == null)
            {
                return BadRequest("El Id de Contratación o Empleado presenta errores");
            }

            // Obtiene el añoId
            var TablaAnio = await _Context.Anios.AsNoTracking().FirstOrDefaultAsync(a => a.Nombre == _EmpleadoContratacion_VM.AnioNombre);
            if (TablaAnio == null)
            {
                return BadRequest("Error con el año");
            }


            try
            {

                Contratacion _Contratacion_1 = new Contratacion()
                {
                    ContratacionId = (int)_EmpleadoContratacion_VM.ContratacionId,
                    AnioId = TablaAnio.AnioId,
                    EmpleadoId = (int)_EmpleadoContratacion_VM.EmpleadoId,
                    FechaContratacion = _EmpleadoContratacion_VM.FechaContratacion,
                    PuestoLaboralId = _EmpleadoContratacion_VM.PuestoLaboralId,
                    MetaPresupuestalId = _EmpleadoContratacion_VM.MetaPresupuestalId,
                    OrdenServicio = _EmpleadoContratacion_VM.OrdenServicio,
                    ContratacionDescripcion = _EmpleadoContratacion_VM.ContratacionDescripcion,
                    Remuneracion = _EmpleadoContratacion_VM.Remuneracion,

                    FechaCreacion = DateTime.Now,
                    UsuarioModificacionId = _EmpleadoContratacion_VM.UsuarioModificacionId,
                    Activo = _EmpleadoContratacion_VM.Activo,

                };

                // Carga de Archivo
                    
                var ruta = @$"{_archivoSettings.Ruta}{_EmpleadoContratacion_VM.NumDoc}\";
                if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                    
                if (_EmpleadoContratacion_VM.ArchivoOrdenServicio != null)
                {
                    var archivoOrdenServicio = _EmpleadoContratacion_VM.ArchivoOrdenServicio;
                    var fullPath = string.Concat(ruta, archivoOrdenServicio.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await archivoOrdenServicio.CopyToAsync(fileStream);
                        _Contratacion_1.ArchivoOrdenServicio = fullPath;
                    }
                }
                
                _Context.Contrataciones.Update(_Contratacion_1);
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

            return NoContent();


        }



        [HttpDelete("[action]")]
        public async Task<IActionResult> BorraContratacion(int ContratacionesId, int UsuarioModificacionId)
        {
            var ExisteContratacion = await _Context.Contrataciones.AsNoTracking().FirstOrDefaultAsync(e => e.ContratacionId== ContratacionesId);
            if (ExisteContratacion == null)
            {
                return BadRequest("El Id de Contratación");
            }

            // -- Modifica en BD --
            try
            {
                var TablaContratacion = new Contratacion() { ContratacionId = ContratacionesId, UsuarioModificacionId= UsuarioModificacionId, FechaModificacion=DateTime.Now,  Activo = false };
                _Context.Attach(TablaContratacion);
                _Context.Entry(TablaContratacion).Property(r => r.UsuarioModificacionId).IsModified = true;
                _Context.Entry(TablaContratacion).Property(r => r.FechaModificacion).IsModified = true;
                _Context.Entry(TablaContratacion).Property(r => r.Activo).IsModified = true;
                _Context.SaveChanges();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

            return NoContent();

        }





    }
}
