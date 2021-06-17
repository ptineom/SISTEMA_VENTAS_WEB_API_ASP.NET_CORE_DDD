using SistemaVentas.Cross.Utils.Constantes;
using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Domain.Entities;
using SistemaVentas.Domain.RepositoriesContracts;
using SistemaVentas.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.Services.Implementations
{
    public class ProveedorDomainService : IProveedorDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProveedorDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseObject> RegisterAsync(Proveedor obj)
        {
            try
            {
                await _unitOfWork.ProveedorRepository.RegisterAsync(obj);
                return new ResponseObject() { Message = Generales.INSERT_SUCCESS, Data = obj.IdProveedor };
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    Success = false,
                    Message = Generales.INSERT_ERROR,
                    ErrorDetails = new ErrorDetails() { StatusCode = 500, Message = ex.Message }
                };
            }
        }
        public async Task<ResponseObject> UpdateAsync(Proveedor obj)
        {
            try
            {
                await _unitOfWork.ProveedorRepository.UpdateAsync(obj);
                return new ResponseObject() { Message = Generales.UPDATE_SUCCESS };
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    Success = false,
                    Message = Generales.INSERT_ERROR,
                    ErrorDetails = new ErrorDetails() { StatusCode = 500, Message = ex.Message }
                };
            }
        }
        public async Task<ResponseObject> DeleteAsync(Proveedor obj)
        {
            try
            {
                await _unitOfWork.ProveedorRepository.DeleteAsync(obj);
                return new ResponseObject() { Message = Generales.DELETE_SUCCESS };
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    Success = false,
                    Message = Generales.DELETE_ERROR,
                    ErrorDetails = new ErrorDetails() { StatusCode = 500, Message = ex.Message }
                };
            }
        }
        public async Task<List<Proveedor>> GetAllAsync(Proveedor obj)
        {
            return await _unitOfWork.ProveedorRepository.GetAllAsync(obj);
        }

        public async Task<Proveedor> GetByIdAsync(string id)
        {
            return await _unitOfWork.ProveedorRepository.GetByIdAsync(id);
        }
        public async Task<Proveedor> GetByDocument(Proveedor obj)
        {
            return await _unitOfWork.ProveedorRepository.GetByDocument(obj);
        }
    }
}
