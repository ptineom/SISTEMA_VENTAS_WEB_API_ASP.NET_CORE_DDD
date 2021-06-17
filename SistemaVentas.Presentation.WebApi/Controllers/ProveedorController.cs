using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Aplication.Services.Contracts;
using SistemaVentas.Aplication.Services.Security.Contracts;
using SistemaVentas.Cross.Utils;
using SistemaVentas.Cross.Utils.Constantes;
using SistemaVentas.Cross.Utils.DTOGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemaVentas.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;
        private readonly ISessionIdentity _sessionIdentity;
        string _idUsuario = string.Empty;
        public ProveedorController(IProveedorService proveedorService, ISessionIdentity sessionIdentity)
        {
            _proveedorService = proveedorService;
            _sessionIdentity = sessionIdentity;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromQuery] string idProveedor, [FromQuery] string nomProveedor, [FromQuery] bool flgConInactivos = false)
        {
            List<ProveedorDTOResponse> result = await _proveedorService.GetAllAsync(new ProveedorDTORequest()
            {
                IdProveedor = idProveedor,
                NomProveedor = nomProveedor,
                FlgInactivo = flgConInactivos
            });

            var response = new ResponseObject()
            {
                Data = result.Select(x => new
                {
                    IdProveedor = x.IdProveedor,
                    NomProveedor = ViewHelper.CapitalizeAll(x.NomProveedor),
                    NomTipoDocumento = x.Abreviatura,
                    NroDocumento = x.NroDocumento,
                    DirProveedor = ViewHelper.CapitalizeAll(x.DirProveedor),
                    IdTipoDocumento = x.IdTipoDocumento
                })
            };

            return Ok(response);
        }
        [HttpGet("GetByDocument/{idTipoDocumento}/{nroDocumento}")]
        public async Task<IActionResult> GetByDocumentAsync(int idTipoDocumento, string nroDocumento)
        {
            var result = await Task.Run(() => _proveedorService.GetByDocument(new ProveedorDTORequest()
            {
                IdTipoDocumento = idTipoDocumento,
                NroDocumento = nroDocumento
            }));

            if (result == null)
                return NotFound(new ResponseObject()
                {
                    Success = false,
                    Message = "El proveedor no existe.",
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = Generales.NOT_FOUND
                    }
                });

            var response = new ResponseObject()
            {
                Data = new
                {
                    IdProveedor = result.IdProveedor,
                    IdTipoDocumento = result.IdTipoDocumento,
                    NroDocumento = result.NroDocumento,
                    NomProveedor = result.NomProveedor,
                    DirProveedor = result.DirProveedor
                }
            };

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] ProveedorDTORequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = JsonSerializer.Serialize(ModelState)
                    }
                });
            }

            request.IdUsuarioRegistro = _sessionIdentity.GetUserLogged().IdUsuario;
            ResponseObject result = await _proveedorService.RegisterAsync(request);

            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = result.ErrorDetails.Message
                    }
                });
            }

            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProveedorDTORequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = JsonSerializer.Serialize(ModelState)
                    }
                });
            }

            request.IdUsuarioRegistro = _sessionIdentity.GetUserLogged().IdUsuario;
            ResponseObject responseObject = await _proveedorService.UpdateAsync(request);

            if (!responseObject.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = responseObject.ErrorDetails.Message
                    }
                });
            }

            return Ok(responseObject);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] ProveedorDTORequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = JsonSerializer.Serialize(ModelState)
                    }
                });
            }

            request.IdUsuarioRegistro = _sessionIdentity.GetUserLogged().IdUsuario;
            ResponseObject result = await _proveedorService.DeleteAsync(request);

            if (!result.Success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = result.ErrorDetails.Message
                    }
                });
            }

            return Ok(result);
        }
    }
}
