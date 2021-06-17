using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Cross.Utils.DTOGeneric;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Aplication.Services.Contracts
{
    public interface IClienteService
    {
        Task<ResponseObject> RegisterAsync(ClienteDTORequest obj);
        Task<ResponseObject> UpdateAsync(ClienteDTORequest obj);
        Task<ResponseObject> DeleteAsync(ClienteDTORequest obj);
        Task<List<ClienteDTOResponse>> GetAllAsync(ClienteDTORequest obj);
        Task<ClienteDTOResponse> GetByIdAsync(string id);
        Task<ClienteDTOResponse> GetByDocument(ClienteDTORequest obj);
    }
}
