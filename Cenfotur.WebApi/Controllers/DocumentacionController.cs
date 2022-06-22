using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
    [Route("api/documentaciones")]
    [ApiController]
    public class DocumentacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ArchivoSettings _archivoSettings;

        public DocumentacionController(ApplicationDbContext context, IMapper mapper, IOptions<ArchivoSettings> archivoSettings)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _archivoSettings = archivoSettings.Value ?? throw new ArgumentNullException(nameof(archivoSettings));
        }

        [HttpPost]
        [RequestSizeLimit(100_000_000)]
        public async Task<IActionResult> Post([FromForm]Documentacion_I_DTO documentoIDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var documentacion = _mapper.Map<Documentacion>(documentoIDto);
                documentacion.FechaCreacion = DateTime.Now;
                _context.Add(documentacion);

                // Carga de Archivo

                var ruta = @$"{_archivoSettings.RutaDocumentos}{DateTime.Now:dd.MM.yyyy}\{documentacion.CapacitacionId}\";
                if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                
                if (documentoIDto.TdrFacilitador != null)
                {
                    var tdrFacilitador = documentoIDto.TdrFacilitador;
                    var fullPath = string.Concat(ruta, tdrFacilitador.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await tdrFacilitador.CopyToAsync(fileStream);
                        documentacion.TdrFacilitador = fullPath;
                    }
                }
                
                if (documentoIDto.OsFacilitador != null)
                {
                    var osFacilitador = documentoIDto.OsFacilitador;
                    var fullPath = string.Concat(ruta, osFacilitador.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await osFacilitador.CopyToAsync(fileStream);
                        documentacion.OsFacilitador = fullPath;
                    }
                }
                
                if (documentoIDto.TdrGestor != null)
                {
                    var tdrGestor = documentoIDto.TdrGestor;
                    var fullPath = string.Concat(ruta, tdrGestor.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await tdrGestor.CopyToAsync(fileStream);
                        documentacion.TdrGestor = fullPath;
                    }
                }
                
                if (documentoIDto.OsGestor != null)
                {
                    var osGestor = documentoIDto.OsGestor;
                    var fullPath = string.Concat(ruta, osGestor.FileName);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await osGestor.CopyToAsync(fileStream);
                        documentacion.OsGestor = fullPath;
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
        public async Task<IActionResult> Put([FromForm]Documentacion_I_DTO documentoIDto, int id)
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
                    var documentoDb = _mapper.Map<Documentacion>(documentoIDto);
                    documentoDb.DocumentacionId = id;
                    documentoDb.FechaModificacion = DateTime.Now;
                    documentoDb.UsuarioModificacionId = documentoIDto.UsuarioModificacionId;

                    // Carga de Archivo

                    var ruta = @$"{_archivoSettings.RutaDocumentos}{DateTime.Now:dd.MM.yyyy}\{documentoDb.CapacitacionId}\";
                    if (!Directory.Exists(ruta)) Directory.CreateDirectory(ruta);
                    
                    if (documentoIDto.TdrFacilitador != null)
                    {
                        var tdrFacilitador = documentoIDto.TdrFacilitador;
                        var fullPath = string.Concat(ruta, tdrFacilitador.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await tdrFacilitador.CopyToAsync(fileStream);
                            documentoDb.TdrFacilitador = fullPath;
                        }
                    }
                    
                    if (documentoIDto.OsFacilitador != null)
                    {
                        var osFacilitador = documentoIDto.OsFacilitador;
                        var fullPath = string.Concat(ruta, osFacilitador.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await osFacilitador.CopyToAsync(fileStream);
                            documentoDb.OsFacilitador = fullPath;
                        }
                    }
                    
                    if (documentoIDto.TdrGestor != null)
                    {
                        var tdrGestor = documentoIDto.TdrGestor;
                        var fullPath = string.Concat(ruta, tdrGestor.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await tdrGestor.CopyToAsync(fileStream);
                            documentoDb.TdrGestor = fullPath;
                        }
                    }
                    
                    if (documentoIDto.OsGestor != null)
                    {
                        var osGestor = documentoIDto.OsGestor;
                        var fullPath = string.Concat(ruta, osGestor.FileName);
                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await osGestor.CopyToAsync(fileStream);
                            documentoDb.OsGestor = fullPath;
                        }
                    }
                    _context.Update(documentoDb);
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
                var documentoDb = await _context.Documentaciones.FirstOrDefaultAsync(e => e.DocumentacionId == id);
                if (documentoDb != null)
                {
                    documentoDb.FechaModificacion = DateTime.Now;
                    documentoDb.UsuarioModificacionId = usuarioModificacionId;
                    documentoDb.Activo = false;
                    _context.Update(documentoDb);

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