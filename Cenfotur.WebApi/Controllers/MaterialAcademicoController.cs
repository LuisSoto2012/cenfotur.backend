using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cenfotur.Data;
using Cenfotur.Entidad.DTOS.Input;
using Cenfotur.Entidad.Models;
using Cenfotur.Entidad.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cenfotur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialAcademicoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ArchivoSettings _archivoSettings;

        public MaterialAcademicoController(ApplicationDbContext context, IMapper mapper, IOptions<ArchivoSettings> archivoSettings)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _archivoSettings = archivoSettings.Value ?? throw new ArgumentNullException(nameof(archivoSettings));
        }
        
        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> Post([FromForm]MaterialAcademico_I_DTO materialAcademicoIDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var materialAcademico = _mapper.Map<MaterialAcademico>(materialAcademicoIDto);
                materialAcademico.FechaCreacion = DateTime.Now;
                _context.Add(materialAcademico);

                // Carga de Archivo

                var ruta = @$"{_archivoSettings.RutaCapacitaciones}{materialAcademico.CapacitacionId}\MaterialAcademico\";
                if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                
                if (materialAcademicoIDto.FichaParticipante != null)
                {
                    var fichaParticipante = materialAcademicoIDto.FichaParticipante;
                    var fullPath = string.Concat(ruta, fichaParticipante.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await fichaParticipante.CopyToAsync(fileStream);
                        materialAcademico.FichaParticipante = fullPath;
                    }
                }
                
                if (materialAcademicoIDto.FichaEmpresa != null)
                {
                    var fichaEmpresa = materialAcademicoIDto.FichaEmpresa;
                    var fullPath = string.Concat(ruta, fichaEmpresa.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await fichaEmpresa.CopyToAsync(fileStream);
                        materialAcademico.FichaEmpresa = fullPath;
                    }
                }
                
                if (materialAcademicoIDto.GesInstructivos != null)
                {
                    var gesInstructivos = materialAcademicoIDto.GesInstructivos;
                    var fullPath = string.Concat(ruta, gesInstructivos.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await gesInstructivos.CopyToAsync(fileStream);
                        materialAcademico.GesInstructivos = fullPath;
                    }
                }
                
                if (materialAcademicoIDto.GesFormatoInforme != null)
                {
                    var gesFormatoInforme = materialAcademicoIDto.GesFormatoInforme;
                    var fullPath = string.Concat(ruta, gesFormatoInforme.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await gesFormatoInforme.CopyToAsync(fileStream);
                        materialAcademico.GesFormatoInforme = fullPath;
                    }
                }
                
                if (materialAcademicoIDto.Sillabus != null)
                {
                    var sillabus = materialAcademicoIDto.Sillabus;
                    var fullPath = string.Concat(ruta, sillabus.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await sillabus.CopyToAsync(fileStream);
                        materialAcademico.Sillabus = fullPath;
                    }
                }
                
                if (materialAcademicoIDto.Ppt != null)
                {
                    var ppt = materialAcademicoIDto.Ppt;
                    var fullPath = string.Concat(ruta, ppt.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await ppt.CopyToAsync(fileStream);
                        materialAcademico.Ppt = fullPath;
                    }
                }
                
                if (materialAcademicoIDto.Evaluaciones != null)
                {
                    var evaluaciones = materialAcademicoIDto.Evaluaciones;
                    var fullPath = string.Concat(ruta, evaluaciones.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await evaluaciones.CopyToAsync(fileStream);
                        materialAcademico.Evaluaciones = fullPath;
                    }
                }
                
                if (materialAcademicoIDto.FacInstructivos != null)
                {
                    var facInstructivos = materialAcademicoIDto.FacInstructivos;
                    var fullPath = string.Concat(ruta, facInstructivos.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await facInstructivos.CopyToAsync(fileStream);
                        materialAcademico.FacInstructivos = fullPath;
                    }
                }
                
                if (materialAcademicoIDto.FacFormatoInforme != null)
                {
                    var facFormatoInforme = materialAcademicoIDto.FacFormatoInforme;
                    var fullPath = string.Concat(ruta, facFormatoInforme.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await facFormatoInforme.CopyToAsync(fileStream);
                        materialAcademico.FacFormatoInforme = fullPath;
                    }
                }

                await _context.SaveChangesAsync();
                
                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.ToString());
            }
            
            return Ok();
        }
        
        [HttpPut("{id:int}")]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> Put([FromForm]MaterialAcademico_I_DTO materialAcademicoIDto, int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }
            
            try
            {
                var Existe = await _context.Documentaciones.AnyAsync(e => e.DocumentacionId == id);
                if (Existe)
                {
                    var materialAcademicoDb = _mapper.Map<MaterialAcademico>(materialAcademicoIDto);
                    materialAcademicoDb.MaterialAcademicoId = id;
                    materialAcademicoDb.FechaModificacion = DateTime.Now;
                    materialAcademicoDb.UsuarioModificacionId = materialAcademicoIDto.UsuarioModificacionId;

                    // Carga de Archivo

                    var ruta = @$"{_archivoSettings.RutaCapacitaciones}{materialAcademicoDb.CapacitacionId}\MaterialAcademico\";
                    if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                    
                    if (materialAcademicoIDto.FichaParticipante != null)
                    {
                        var fichaParticipante = materialAcademicoIDto.FichaParticipante;
                        var fullPath = string.Concat(ruta, fichaParticipante.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await fichaParticipante.CopyToAsync(fileStream);
                            materialAcademicoDb.FichaParticipante = fullPath;
                        }
                    }
                    
                    if (materialAcademicoIDto.FichaEmpresa != null)
                    {
                        var fichaEmpresa = materialAcademicoIDto.FichaEmpresa;
                        var fullPath = string.Concat(ruta, fichaEmpresa.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await fichaEmpresa.CopyToAsync(fileStream);
                            materialAcademicoDb.FichaEmpresa = fullPath;
                        }
                    }
                    
                    if (materialAcademicoIDto.GesInstructivos != null)
                    {
                        var gesInstructivos = materialAcademicoIDto.GesInstructivos;
                        var fullPath = string.Concat(ruta, gesInstructivos.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await gesInstructivos.CopyToAsync(fileStream);
                            materialAcademicoDb.GesInstructivos = fullPath;
                        }
                    }
                    
                    if (materialAcademicoIDto.GesFormatoInforme != null)
                    {
                        var gesFormatoInforme = materialAcademicoIDto.GesFormatoInforme;
                        var fullPath = string.Concat(ruta, gesFormatoInforme.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await gesFormatoInforme.CopyToAsync(fileStream);
                            materialAcademicoDb.GesFormatoInforme = fullPath;
                        }
                    }
                    
                    if (materialAcademicoIDto.Sillabus != null)
                    {
                        var sillabus = materialAcademicoIDto.Sillabus;
                        var fullPath = string.Concat(ruta, sillabus.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await sillabus.CopyToAsync(fileStream);
                            materialAcademicoDb.Sillabus = fullPath;
                        }
                    }
                    
                    if (materialAcademicoIDto.Ppt != null)
                    {
                        var ppt = materialAcademicoIDto.Ppt;
                        var fullPath = string.Concat(ruta, ppt.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await ppt.CopyToAsync(fileStream);
                            materialAcademicoDb.Ppt = fullPath;
                        }
                    }
                    
                    if (materialAcademicoIDto.Evaluaciones != null)
                    {
                        var evaluaciones = materialAcademicoIDto.Evaluaciones;
                        var fullPath = string.Concat(ruta, evaluaciones.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await evaluaciones.CopyToAsync(fileStream);
                            materialAcademicoDb.Evaluaciones = fullPath;
                        }
                    }
                    
                    if (materialAcademicoIDto.FacInstructivos != null)
                    {
                        var facInstructivos = materialAcademicoIDto.FacInstructivos;
                        var fullPath = string.Concat(ruta, facInstructivos.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await facInstructivos.CopyToAsync(fileStream);
                            materialAcademicoDb.FacInstructivos = fullPath;
                        }
                    }
                    
                    if (materialAcademicoIDto.FacFormatoInforme != null)
                    {
                        var facFormatoInforme = materialAcademicoIDto.FacFormatoInforme;
                        var fullPath = string.Concat(ruta, facFormatoInforme.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await facFormatoInforme.CopyToAsync(fileStream);
                            materialAcademicoDb.FacFormatoInforme = fullPath;
                        }
                    }
                    _context.Update(materialAcademicoDb);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpDelete("{id:int}/{usuarioModificacionId:int}")]
        public async Task<ActionResult> Delete(int id, int usuarioModificacionId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(id.ToString()) == true)
            {
                return BadRequest("El Id es invalido");
            }

            try
            {
                var materialAcademicoDb = await _context.MaterialesAcademicos.FirstOrDefaultAsync(e => e.MaterialAcademicoId == id);
                if (materialAcademicoDb != null)
                {
                    materialAcademicoDb.FechaModificacion = DateTime.Now;
                    materialAcademicoDb.UsuarioModificacionId = usuarioModificacionId;
                    materialAcademicoDb.Activo = false;
                    _context.Update(materialAcademicoDb);

                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}