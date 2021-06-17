using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Aplication.Services.Security.Contracts;
using SistemaVentas.Cross.Utils;
using SistemaVentas.Cross.Utils.Constantes;
using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Presentation.WebApi.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemaVentas.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly ITokenProcess _tokenProcess;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IConfiguration _configuration;

        public AccountController(ISecurityService securityService, ITokenProcess tokenProcess,
            IRefreshTokenService refreshTokenService, IConfiguration configuration)
        {
            _securityService = securityService;
            _tokenProcess = tokenProcess;
            _refreshTokenService = refreshTokenService;
            _configuration = configuration;
        }

        [HttpPost("UserValidation")]
        [AllowAnonymous]
        public async Task<IActionResult> UserValidationAsync([FromBody]LoginRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = JsonSerializer.Serialize(ModelState)
                    }
                });

            if (string.IsNullOrWhiteSpace(request.userId) || string.IsNullOrWhiteSpace(request.password))
                return NotFound(new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Usuario y/o contraseña incorrectas"
                    }
                });

            //Validamos el usuario
            ResponseObject result = await _securityService.UserValidationAsync(request.userId, request.password);

            if (!result.Success)
                return NotFound(new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = result.ErrorDetails.Message
                    }
                });

            //Obtenemos los datos del usuario validado satisfactoriamente.
            var model = (UsuarioAuthDTOResponse)result.Data;

            if (model.CountSucursales == 0)
                return NotFound(new ResponseObject()
                {
                    Success = false,
                    ErrorDetails = new ErrorDetails()
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "El usuario no tiene configurado al menos 1 sucursal."
                    }
                });

            //Si El usuario tiene solo una sucursal configurada, crearemos el JWT
            if (model.CountSucursales == 1)
            {
                var modelClaims = new AuthDTORequest()
                {
                    IdUsuario = model.IdUsuario,
                    NomUsuario = model.NomUsuario,
                    NomRol = model.NomRol,
                    IdSucursal = model.IdSucursal,
                    NomSucursal = model.NomSucursal,
                    FlgCtrlTotal = model.FlgCtrlTotal
                };
                IEnumerable<Claim> claims = _tokenProcess.GenerateClaims(modelClaims);

                //Generamos el token y refreshToken.
                string token = _tokenProcess.GenerateToken(claims);
                string refreshToken = _tokenProcess.GenerateRefreshToken();

                //Serializamos los claims
                string jsonClaims = JsonSerializer.Serialize(modelClaims);

                //Grabamos el JWT en la bd.
                await _refreshTokenService.RegisterAsync(new RefreshTokenDTORequest()
                {
                    IdRefreshToken = Encode.GetHash256(refreshToken),
                    IdUsuarioToken = model.IdUsuario,
                    TiempoExpiracionMinutos = Convert.ToInt32(_configuration.GetSection("Jwt:RefreshTokenExpireMinutes").Value),
                    FecCreacionUtc = DateTime.UtcNow,
                    IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    IdUsuarioRegistro = model.IdUsuario,
                    JsonClaims = jsonClaims
                });

                result = new ResponseObject()
                {
                    Data = new
                    {
                        token,
                        refreshToken,
                        flgVariasSucursales = false,
                        menuItem = "",
                        avatarB64 = ""
                    }
                };
            }
            else if (model.CountSucursales > 1)
            {
                //Recuperamos las sucursales del usuario
                var list = await _securityService.GetCampusByUserIdAsync(model.IdUsuario);

                result = new ResponseObject()
                {
                    Data = new
                    {
                        flgVariasSucursales = true,
                        listSucursales = list
                    }
                };
            }

            return Ok(result);
        }
    }
}
