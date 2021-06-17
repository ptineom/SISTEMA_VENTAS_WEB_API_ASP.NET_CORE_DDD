using SistemaVentas.Aplication.DTO.Request;
using SistemaVentas.Aplication.DTO.Response;
using SistemaVentas.Cross.Utils.DTOGeneric;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Aplication.Services.Contracts
{
    public interface IProveedorService
    {
        Task<ResponseObject> RegisterAsync(ProveedorDTORequest obj);
        Task<ResponseObject> UpdateAsync(ProveedorDTORequest obj);
        Task<ResponseObject> DeleteAsync(ProveedorDTORequest obj);
        Task<List<ProveedorDTOResponse>> GetAllAsync(ProveedorDTORequest obj);
        Task<ProveedorDTOResponse> GetByIdAsync(string id);
        Task<ProveedorDTOResponse> GetByDocument(ProveedorDTORequest obj);
    }
}
