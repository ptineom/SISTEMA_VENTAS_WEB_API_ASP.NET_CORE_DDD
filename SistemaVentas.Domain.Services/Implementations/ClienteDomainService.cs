using SistemaVentas.Cross.Utils.Constantes;
using SistemaVentas.Cross.Utils.DTOGeneric;
using SistemaVentas.Domain.Entities;
using SistemaVentas.Domain.RepositoriesContracts.Contracts;
using SistemaVentas.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Domain.Services.Implementations
{
    public class ClienteDomainService : IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async Task<ResponseObject> DeleteAsync(Cliente obj)
        {
            try
            {
                await _clienteRepository.DeleteAsync(obj);

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

        public async Task<List<Cliente>> GetAllAsync(Cliente obj)
        {
            return await _clienteRepository.GetAllAsync(obj);
        }

        public async Task<Cliente> GetByDocument(Cliente obj)
        {
            return await _clienteRepository.GetByDocument(obj);
        }

        public async Task<Cliente> GetByIdAsync(string id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task<ResponseObject> RegisterAsync(Cliente obj)
        {
            try
            {
                await _clienteRepository.RegisterAsync(obj);

                return new ResponseObject() { Message = Generales.INSERT_SUCCESS, Data = obj.IdCliente };
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

        public async Task<ResponseObject> UpdateAsync(Cliente obj)
        {
            try
            {
                await _clienteRepository.UpdateAsync(obj);

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
    }
}
