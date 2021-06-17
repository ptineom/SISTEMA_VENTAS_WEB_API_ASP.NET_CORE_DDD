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
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConnection _db;
        private readonly string _storeProcedure = "PA_MANT_CLIENTE";
        public ClienteRepository(IConnection db)
        {
            _db = db;
        }
        public async Task<List<Cliente>> GetAllAsync(Cliente obj)
        {
            List<Cliente> listCliente = null;
            var parameters = new DynamicParameters();

            string tipoFiltro = "descripcion";
            string filtro = "";

            if (!string.IsNullOrEmpty(obj.IdCliente) && string.IsNullOrEmpty(obj.NomCliente) && string.IsNullOrEmpty(obj.NroDocumento))
            {
                tipoFiltro = "codigo";
                filtro = obj.IdCliente;
            }
            else if (!string.IsNullOrEmpty(obj.NomCliente) && string.IsNullOrEmpty(obj.IdCliente) && string.IsNullOrEmpty(obj.NroDocumento))
            {
                tipoFiltro = "descripcion";
                filtro = obj.NomCliente;
            }
            else if (!string.IsNullOrEmpty(obj.NroDocumento) && string.IsNullOrEmpty(obj.IdCliente) && string.IsNullOrEmpty(obj.NomCliente))
            {
                tipoFiltro = "numDoc";
                filtro = obj.NomCliente;
            }

            parameters.Add("@ACCION", "SEL", direction: ParameterDirection.Input);
            parameters.Add("@TIPO_FILTRO", tipoFiltro, direction: ParameterDirection.Input);
            parameters.Add("@FILTRO", filtro, direction: ParameterDirection.Input);
            parameters.Add("@FLG_INACTIVO", obj.FlgInactivo, direction: ParameterDirection.Input);

            var reader = await _db.DbConnection.ExecuteReaderAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure);

            if (reader.FieldCount > 0)
            {
                listCliente = new List<Cliente>();
                while (reader.Read())
                {
                    listCliente.Add(new Cliente()
                    {
                        IdCliente = reader.GetString(reader.GetOrdinal("ID_CLIENTE")),
                        NomCliente = reader.GetString(reader.GetOrdinal("NOM_CLIENTE")),
                        Abreviatura = reader.GetString(reader.GetOrdinal("ABREVIATURA")),
                        NroDocumento = reader.GetString(reader.GetOrdinal("NRO_DOCUMENTO")),
                        TelCliente = reader.IsDBNull(reader.GetOrdinal("TEL_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("TEL_CLIENTE")),
                        EmailCliente = reader.IsDBNull(reader.GetOrdinal("EMAIL_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("EMAIL_CLIENTE")),
                        FlgInactivo = reader.GetBoolean(reader.GetOrdinal("FLG_INACTIVO")),
                        IdTipoDocumento = reader.GetInt32(reader.GetOrdinal("ID_TIPO_DOCUMENTO")),
                        DirCliente = reader.IsDBNull(reader.GetOrdinal("DIR_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("DIR_CLIENTE"))
                    });
                }
            }
            reader.Dispose();

            return listCliente;
        }

        public async Task<Cliente> GetByDocument(Cliente obj)
        {
            Cliente model = null;
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "NRO", direction: ParameterDirection.Input);
            parameters.Add("@ID_TIPO_DOCUMENTO", obj.IdTipoDocumento, direction: ParameterDirection.Input);
            parameters.Add("@ID_PROVEEDOR", obj.NroDocumento, direction: ParameterDirection.Input);

            var reader = await _db.DbConnection.ExecuteReaderAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure);

            if (reader.FieldCount > 0)
            {
                if (reader.Read())
                {
                    model = new Cliente()
                    {
                        IdCliente = reader.GetString(reader.GetOrdinal("ID_CLIENTE")),
                        IdTipoDocumento = reader.GetInt32(reader.GetOrdinal("ID_TIPO_DOCUMENTO")),
                        NroDocumento = reader.GetString(reader.GetOrdinal("NRO_DOCUMENTO")),
                        NomCliente = reader.IsDBNull(reader.GetOrdinal("NOM_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("NOM_CLIENTE")),
                        DirCliente = reader.IsDBNull(reader.GetOrdinal("DIR_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("DIR_CLIENTE")),
                    };
                }
            }
            reader.Dispose();

            return model;
        }

        public async Task<Cliente> GetByIdAsync(string id)
        {
            Cliente model = null;
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "GET", direction: ParameterDirection.Input);
            parameters.Add("@ID_PROVEEDOR", id, direction: ParameterDirection.Input);

            var reader = await _db.DbConnection.ExecuteReaderAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure);

            if (reader.FieldCount > 0)
            {
                if (reader.Read())
                {
                    model = new Cliente()
                    {
                        IdCliente = reader.GetString(reader.GetOrdinal("ID_CLIENTE")),
                        IdTipoDocumento = reader.GetInt32(reader.GetOrdinal("ID_TIPO_DOCUMENTO")),
                        NroDocumento = reader.GetString(reader.GetOrdinal("NRO_DOCUMENTO")),
                        NomCliente = reader.IsDBNull(reader.GetOrdinal("NOM_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("NOM_CLIENTE")),
                        DirCliente = reader.IsDBNull(reader.GetOrdinal("DIR_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("DIR_CLIENTE")),
                        TelCliente = reader.IsDBNull(reader.GetOrdinal("TEL_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("TEL_CLIENTE")),
                        EmailCliente = reader.IsDBNull(reader.GetOrdinal("EMAIL_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("EMAIL_CLIENTE")),
                        IdUbigeo = reader.IsDBNull(reader.GetOrdinal("ID_UBIGEO")) ? string.Empty : reader.GetString(reader.GetOrdinal("ID_UBIGEO")),
                        ObsCliente = reader.IsDBNull(reader.GetOrdinal("OBS_CLIENTE")) ? string.Empty : reader.GetString(reader.GetOrdinal("OBS_CLIENTE")),
                        Contacto = reader.IsDBNull(reader.GetOrdinal("CONTACTO")) ? string.Empty : reader.GetString(reader.GetOrdinal("CONTACTO")),
                        FlgInactivo = reader.GetBoolean(reader.GetOrdinal("FLG_INACTIVO")),
                        FlgPersonaNatural = reader.GetBoolean(reader.GetOrdinal("FLG_PERSONA_NATURAL")),
                        Sexo = reader.GetString(reader.GetOrdinal("SEXO")),
                        ApellidoPaterno = reader.IsDBNull(reader.GetOrdinal("APELLIDO_PATERNO")) ? string.Empty : reader.GetString(reader.GetOrdinal("APELLIDO_PATERNO")),
                        ApellidoMaterno = reader.IsDBNull(reader.GetOrdinal("APELLIDO_MATERNO")) ? string.Empty : reader.GetString(reader.GetOrdinal("APELLIDO_MATERNO")),
                        Nombres = reader.IsDBNull(reader.GetOrdinal("NOMBRES")) ? string.Empty : reader.GetString(reader.GetOrdinal("NOMBRES")),
                    };
                }
            }
            reader.Dispose();

            return model;
        }

        public async Task<bool> RegisterAsync(Cliente obj, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "INS", direction: ParameterDirection.Input);
            parameters.Add("@ID_CLIENTE", "", direction: ParameterDirection.Output);
            parameters.Add("@ID_TIPO_DOCUMENTO", obj.IdTipoDocumento, direction: ParameterDirection.Input);
            parameters.Add("@NRO_DOCUMENTO", obj.NroDocumento, direction: ParameterDirection.Input);
            parameters.Add("@DIR_CLIENTE", string.IsNullOrEmpty(obj.DirCliente) ? (object)DBNull.Value : obj.DirCliente, direction: ParameterDirection.Input);
            parameters.Add("@TEL_CLIENTE", string.IsNullOrEmpty(obj.TelCliente) ? (object)DBNull.Value : obj.TelCliente, direction: ParameterDirection.Input);
            parameters.Add("@EMAIL_CLIENTE", string.IsNullOrEmpty(obj.EmailCliente) ? (object)DBNull.Value : obj.EmailCliente, direction: ParameterDirection.Input);
            parameters.Add("@ID_UBIGEO", string.IsNullOrEmpty(obj.IdUbigeo) ? (object)DBNull.Value : obj.IdUbigeo, direction: ParameterDirection.Input);
            parameters.Add("@OBS_CLIENTE", string.IsNullOrEmpty(obj.ObsCliente) ? (object)DBNull.Value : obj.ObsCliente, direction: ParameterDirection.Input);
            parameters.Add("@FLG_PERSONA_NATURAL", obj.FlgPersonaNatural, direction: ParameterDirection.Input);
            if (obj.FlgPersonaNatural)
            {
                parameters.Add("@APELLIDO_PATERNO", string.IsNullOrEmpty(obj.ApellidoPaterno) ? (object)DBNull.Value : obj.ApellidoPaterno, direction: ParameterDirection.Input);
                parameters.Add("@APELLIDO_MATERNO", string.IsNullOrEmpty(obj.ApellidoMaterno) ? (object)DBNull.Value : obj.ApellidoMaterno, direction: ParameterDirection.Input);
                parameters.Add("@NOMBRES", string.IsNullOrEmpty(obj.Nombres) ? (object)DBNull.Value : obj.Nombres, direction: ParameterDirection.Input);
                parameters.Add("@SEXO", string.IsNullOrEmpty(obj.Sexo) ? (object)DBNull.Value : obj.Sexo, direction: ParameterDirection.Input);
            }
            else
            {
                parameters.Add("@NOM_CLIENTE", string.IsNullOrEmpty(obj.NomCliente) ? (object)DBNull.Value : obj.NomCliente, direction: ParameterDirection.Input);
                parameters.Add("@CONTACTO", string.IsNullOrEmpty(obj.Contacto) ? (object)DBNull.Value : obj.Contacto, direction: ParameterDirection.Input);
            }
            parameters.Add("@FLG_INACTIVO", obj.FlgInactivo, direction: ParameterDirection.Input);
            parameters.Add("@ID_USUARIO_REGISTRO", obj.IdUsuarioRegistro, direction: ParameterDirection.Input);

            await _db.DbConnection.ExecuteAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

            obj.IdCliente = parameters.Get<string>("@ID_CLIENTE");

            return true;
        }

        public async Task<bool> UpdateAsync(Cliente obj, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "UPD", direction: ParameterDirection.Input);
            parameters.Add("@ID_CLIENTE", "", direction: ParameterDirection.Input);
            parameters.Add("@ID_TIPO_DOCUMENTO", obj.IdTipoDocumento, direction: ParameterDirection.Input);
            parameters.Add("@NRO_DOCUMENTO", obj.NroDocumento, direction: ParameterDirection.Input);
            parameters.Add("@DIR_CLIENTE", string.IsNullOrEmpty(obj.DirCliente) ? (object)DBNull.Value : obj.DirCliente, direction: ParameterDirection.Input);
            parameters.Add("@TEL_CLIENTE", string.IsNullOrEmpty(obj.TelCliente) ? (object)DBNull.Value : obj.TelCliente, direction: ParameterDirection.Input);
            parameters.Add("@EMAIL_CLIENTE", string.IsNullOrEmpty(obj.EmailCliente) ? (object)DBNull.Value : obj.EmailCliente, direction: ParameterDirection.Input);
            parameters.Add("@ID_UBIGEO", string.IsNullOrEmpty(obj.IdUbigeo) ? (object)DBNull.Value : obj.IdUbigeo, direction: ParameterDirection.Input);
            parameters.Add("@OBS_CLIENTE", string.IsNullOrEmpty(obj.ObsCliente) ? (object)DBNull.Value : obj.ObsCliente, direction: ParameterDirection.Input);
            parameters.Add("@FLG_PERSONA_NATURAL", obj.FlgPersonaNatural, direction: ParameterDirection.Input);
            if (obj.FlgPersonaNatural)
            {
                parameters.Add("@APELLIDO_PATERNO", string.IsNullOrEmpty(obj.ApellidoPaterno) ? (object)DBNull.Value : obj.ApellidoPaterno, direction: ParameterDirection.Input);
                parameters.Add("@APELLIDO_MATERNO", string.IsNullOrEmpty(obj.ApellidoMaterno) ? (object)DBNull.Value : obj.ApellidoMaterno, direction: ParameterDirection.Input);
                parameters.Add("@NOMBRES", string.IsNullOrEmpty(obj.Nombres) ? (object)DBNull.Value : obj.Nombres, direction: ParameterDirection.Input);
                parameters.Add("@SEXO", string.IsNullOrEmpty(obj.Sexo) ? (object)DBNull.Value : obj.Sexo, direction: ParameterDirection.Input);
            }
            else
            {
                parameters.Add("@NOM_CLIENTE", string.IsNullOrEmpty(obj.NomCliente) ? (object)DBNull.Value : obj.NomCliente, direction: ParameterDirection.Input);
                parameters.Add("@CONTACTO", string.IsNullOrEmpty(obj.Contacto) ? (object)DBNull.Value : obj.Contacto, direction: ParameterDirection.Input);
            }
            parameters.Add("@FLG_INACTIVO", obj.FlgInactivo, direction: ParameterDirection.Input);
            parameters.Add("@ID_USUARIO_REGISTRO", obj.IdUsuarioRegistro, direction: ParameterDirection.Input);

            await _db.DbConnection.ExecuteAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

            return true;
        }
        public async Task<bool> DeleteAsync(Cliente obj, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", "DEL");
            parameters.Add("@ID_CLIENTE", obj.IdCliente, direction: ParameterDirection.Input);
            parameters.Add("@ID_USUARIO_REGISTRO", obj.IdUsuarioRegistro, direction: ParameterDirection.Input);

            await _db.DbConnection.ExecuteAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

            return true;
        }
    }
}
