using SistemaVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.DTO.Response;

namespace SistemaVentas.Presentation.WebApi.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ProveedorDTORequest, Proveedor>();
            CreateMap<Proveedor, ProveedorDTOResponse>();
            CreateMap<Sucursal, SucursalDTOResponse>();
            CreateMap<Usuario, UsuarioAuthDTOResponse>();
            CreateMap<RefreshToken, RefreshTokenDTOResponse>();
            CreateMap<RefreshTokenDTORequest, RefreshToken>();
            CreateMap<Cliente, ClienteDTOResponse>();
            CreateMap<ClienteDTORequest, Cliente>();
        }
    }
}
