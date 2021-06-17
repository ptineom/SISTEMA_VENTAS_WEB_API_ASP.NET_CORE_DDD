using Dapper;
using SistemaVentas.Domain.Entities;
using SistemaVentas.Domain.RepositoriesContracts;
using SistemaVentas.Domain.RepositoriesContracts.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVentas.Infrastructure.Repositories.Implementations
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly IConnection _db;
        private readonly string _storeProcedure = "PA_MANT_PROVEEDOR";

        public ProveedorRepository(IConnection db)
        {
            _db = db;
        }
        public async Task<List<Proveedor>> GetAllAsync(Proveedor obj)
        {
            List<Proveedor> listProveedor = null;
            var parameters = new DynamicParameters();

            string tipoFiltro = "descripcion";
            string filtro = "";

            if (!string.IsNullOrEmpty(obj.IdProveedor) && string.IsNullOrEmpty(obj.NomProveedor) && string.IsNullOrEmpty(obj.NroDocumento))
            {
                tipoFiltro = "codigo";
                filtro = obj.IdProveedor;
            }
            else if (!string.IsNullOrEmpty(obj.NomProveedor) && string.IsNullOrEmpty(obj.IdProveedor) && string.IsNullOrEmpty(obj.NroDocumento))
            {
                tipoFiltro = "descripcion";
                filtro = obj.NomProveedor;
            }
            else if (!string.IsNullOrEmpty(obj.NroDocumento) && string.IsNullOrEmpty(obj.IdProveedor) && string.IsNullOrEmpty(obj.NomProveedor))
            {
                tipoFiltro = "numDoc";
                filtro = obj.NomProveedor;
            }

            parameters.Add("@ACCION", "SEL", direction: ParameterDirection.Input);
            parameters.Add("@TIPO_FILTRO", tipoFiltro, direction: ParameterDirection.Input);
            parameters.Add("@FILTRO", filtro, direction: ParameterDirection.Input);
            parameters.Add("@FLG_INACTIVO", obj.FlgInactivo, direction: ParameterDirection.Input);

            var reader = await _db.DbConnection.ExecuteReaderAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure);

            if (reader.FieldCount > 0)
            {
                listProveedor = new List<Proveedor>();
                while (reader.Read())
                {
                    listProveedor.Add(new Proveedor()
                    {
                        IdProveedor = reader.GetString(reader.GetOrdinal("ID_PROVEEDOR")),
                        NomProveedor = reader.GetString(reader.GetOrdinal("NOM_PROVEEDOR")),
                        Abreviatura = reader.GetString(reader.GetOrdinal("ABREVIATURA")),
                        NroDocumento = reader.GetString(reader.GetOrdinal("NRO_DOCUMENTO")),
                        TelProveedor = reader.IsDBNull(reader.GetOrdinal("TEL_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("TEL_PROVEEDOR")),
                        EmailProveedor = reader.IsDBNull(reader.GetOrdinal("EMAIL_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("EMAIL_PROVEEDOR")),
                        FlgInactivo = reader.GetBoolean(reader.GetOrdinal("FLG_INACTIVO")),
                        IdTipoDocumento = reader.IsDBNull(reader.GetOrdinal("ID_TIPO_DOCUMENTO")) ? 0 : reader.GetInt32(reader.GetOrdinal("ID_TIPO_DOCUMENTO")),
                        DirProveedor = reader.IsDBNull(reader.GetOrdinal("DIR_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("DIR_PROVEEDOR")),
                        FlgMismaEmpresa = reader.GetBoolean(reader.GetOrdinal("FLG_MISMA_EMPRESA"))
                    });
                }
            }
            reader.Dispose();

            return listProveedor;
        }

        public async Task<Proveedor> GetByIdAsync(string id)
        {
            Proveedor model = null;
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "GET", direction: ParameterDirection.Input);
            parameters.Add("@ID_PROVEEDOR", id, direction: ParameterDirection.Input);

            var reader = await _db.DbConnection.ExecuteReaderAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure);

            if (reader.FieldCount > 0)
            {
                if (reader.Read())
                {
                    model = new Proveedor()
                    {
                        IdProveedor = reader.GetString(reader.GetOrdinal("ID_PROVEEDOR")),
                        IdTipoDocumento = reader.GetInt32(reader.GetOrdinal("ID_TIPO_DOCUMENTO")),
                        NroDocumento = reader.GetString(reader.GetOrdinal("NRO_DOCUMENTO")),
                        NomProveedor = reader.IsDBNull(reader.GetOrdinal("NOM_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("NOM_PROVEEDOR")),
                        DirProveedor = reader.IsDBNull(reader.GetOrdinal("DIR_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("DIR_PROVEEDOR")),
                        TelProveedor = reader.IsDBNull(reader.GetOrdinal("TEL_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("TEL_PROVEEDOR")),
                        EmailProveedor = reader.IsDBNull(reader.GetOrdinal("EMAIL_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("EMAIL_PROVEEDOR")),
                        IdUbigeo = reader.IsDBNull(reader.GetOrdinal("ID_UBIGEO")) ? string.Empty : reader.GetString(reader.GetOrdinal("ID_UBIGEO")),
                        ObsProveedor = reader.IsDBNull(reader.GetOrdinal("OBS_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("OBS_PROVEEDOR")),
                        Contacto = reader.IsDBNull(reader.GetOrdinal("CONTACTO")) ? string.Empty : reader.GetString(reader.GetOrdinal("CONTACTO")),
                        FlgInactivo = reader.GetBoolean(reader.GetOrdinal("FLG_INACTIVO"))
                    };
                }
            }
            reader.Dispose();

            return model;
        }

        public async Task<bool> RegisterAsync(Proveedor obj, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "INS", direction: ParameterDirection.Input);
            parameters.Add("@ID_PROVEEDOR","", direction: ParameterDirection.Output);
            parameters.Add("@NOM_PROVEEDOR", obj.NomProveedor,  direction: ParameterDirection.Input);
            parameters.Add("@ID_TIPO_DOCUMENTO", obj.IdTipoDocumento, direction: ParameterDirection.Input);
            parameters.Add("@NRO_DOCUMENTO", obj.NroDocumento, direction: ParameterDirection.Input);
            parameters.Add("@DIR_PROVEEDOR", string.IsNullOrEmpty(obj.DirProveedor) ? (object)DBNull.Value : obj.DirProveedor, direction: ParameterDirection.Input);
            parameters.Add("@TEL_PROVEEDOR", string.IsNullOrEmpty(obj.TelProveedor) ? (object)DBNull.Value : obj.TelProveedor, direction: ParameterDirection.Input);
            parameters.Add("@EMAIL_PROVEEDOR", string.IsNullOrEmpty(obj.EmailProveedor) ? (object)DBNull.Value : obj.EmailProveedor, direction: ParameterDirection.Input);
            parameters.Add("@ID_UBIGEO", string.IsNullOrEmpty(obj.IdUbigeo) ? (object)DBNull.Value : obj.IdUbigeo, direction: ParameterDirection.Input);
            parameters.Add("@OBS_PROVEEDOR", string.IsNullOrEmpty(obj.ObsProveedor) ? (object)DBNull.Value : obj.ObsProveedor, direction: ParameterDirection.Input);
            parameters.Add("@CONTACTO", string.IsNullOrEmpty(obj.Contacto) ? (object)DBNull.Value : obj.Contacto, direction: ParameterDirection.Input);
            parameters.Add("@FLG_INACTIVO", obj.FlgInactivo, direction: ParameterDirection.Input);
            parameters.Add("@ID_USUARIO_REGISTRO", obj.IdUsuarioRegistro, direction: ParameterDirection.Input);

            await _db.DbConnection.ExecuteAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

            obj.IdProveedor = parameters.Get<string>("@ID_PROVEEDOR");

            return true;
        }

        public async Task<bool> UpdateAsync(Proveedor obj, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "UPD");
            parameters.Add("@ID_PROVEEDOR", obj.IdProveedor, direction: ParameterDirection.Input);
            parameters.Add("@NOM_PROVEEDOR", obj.NomProveedor, direction: ParameterDirection.Input);
            parameters.Add("@ID_TIPO_DOCUMENTO", obj.IdTipoDocumento, direction: ParameterDirection.Input);
            parameters.Add("@NRO_DOCUMENTO", obj.NroDocumento, direction: ParameterDirection.Input);
            parameters.Add("@DIR_PROVEEDOR", string.IsNullOrEmpty(obj.DirProveedor) ? (object)DBNull.Value : obj.DirProveedor, direction: ParameterDirection.Input);
            parameters.Add("@TEL_PROVEEDOR", string.IsNullOrEmpty(obj.TelProveedor) ? (object)DBNull.Value : obj.TelProveedor, direction: ParameterDirection.Input);
            parameters.Add("@EMAIL_PROVEEDOR", string.IsNullOrEmpty(obj.EmailProveedor) ? (object)DBNull.Value : obj.EmailProveedor, direction: ParameterDirection.Input);
            parameters.Add("@ID_UBIGEO", string.IsNullOrEmpty(obj.IdUbigeo) ? (object)DBNull.Value : obj.IdUbigeo, direction: ParameterDirection.Input);
            parameters.Add("@OBS_PROVEEDOR", string.IsNullOrEmpty(obj.ObsProveedor) ? (object)DBNull.Value : obj.ObsProveedor, direction: ParameterDirection.Input);
            parameters.Add("@CONTACTO", string.IsNullOrEmpty(obj.Contacto) ? (object)DBNull.Value : obj.Contacto, direction: ParameterDirection.Input);
            parameters.Add("@FLG_INACTIVO", obj.FlgInactivo, direction: ParameterDirection.Input);
            parameters.Add("@ID_USUARIO_REGISTRO", obj.IdUsuarioRegistro, direction: ParameterDirection.Input);

            await _db.DbConnection.ExecuteAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

            return true;
        }

        public async Task<bool> DeleteAsync(Proveedor obj, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", "DEL");
            parameters.Add("@ID_PROVEEDOR", obj.IdProveedor, direction: ParameterDirection.Input);
            parameters.Add("@ID_USUARIO_REGISTRO", obj.IdUsuarioRegistro, direction: ParameterDirection.Input);

            await _db.DbConnection.ExecuteAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

            return true;
        }

        public async Task<Proveedor> GetByDocument(Proveedor obj)
        {
            Proveedor model = null;
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "NRO", direction: ParameterDirection.Input);
            parameters.Add("@ID_TIPO_DOCUMENTO", obj.IdTipoDocumento, direction: ParameterDirection.Input);
            parameters.Add("@NRO_DOCUMENTO", obj.NroDocumento, direction: ParameterDirection.Input);

            var reader = await _db.DbConnection.ExecuteReaderAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure);

            if (reader.FieldCount > 0)
            {
                if (reader.Read())
                {
                    model = new Proveedor()
                    {
                        IdProveedor = reader.GetString(reader.GetOrdinal("ID_PROVEEDOR")),
                        IdTipoDocumento = reader.GetInt32(reader.GetOrdinal("ID_TIPO_DOCUMENTO")),
                        NroDocumento = reader.GetString(reader.GetOrdinal("NRO_DOCUMENTO")),
                        NomProveedor = reader.IsDBNull(reader.GetOrdinal("NOM_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("NOM_PROVEEDOR")),
                        DirProveedor = reader.IsDBNull(reader.GetOrdinal("DIR_PROVEEDOR")) ? string.Empty : reader.GetString(reader.GetOrdinal("DIR_PROVEEDOR"))
                    };
                }
            }
            reader.Dispose();

            return model;
        }
    }
}
