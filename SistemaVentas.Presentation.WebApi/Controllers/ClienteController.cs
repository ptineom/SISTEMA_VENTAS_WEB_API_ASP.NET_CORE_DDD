using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Aplication.Services.Contracts;
using SistemaVentas.Aplication.Services.Security.Contracts;
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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ISessionIdentity _sessionIdentity;

        public ClienteController(IClienteService clienteService, ISessionIdentity sessionIdentity)
        {
            _clienteService = clienteService;
            _sessionIdentity = sessionIdentity;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromQuery] string idCliente, [FromQuery] string nomCliente)
        {
            List<ClienteDTOResponse> result = await _clienteService.GetAllAsync(new ClienteDTORequest()
            {
                IdCliente = idCliente,
                NomCliente = nomCliente
            });

            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] ClienteDTORequest request)
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
            ResponseObject result = await _clienteService.RegisterAsync(request);

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
        public async Task<IActionResult> UpdateAsync([FromBody] ClienteDTORequest request)
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
            ResponseObject responseObject = await _clienteService.UpdateAsync(request);

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
        public async Task<IActionResult> DeleteAsync([FromBody] ClienteDTORequest request)
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
            ResponseObject responseObject = await _clienteService.DeleteAsync(request);

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
    }
}
