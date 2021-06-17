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
    public class SecurityRepository : ISecurityRepository
    {
        private readonly IConnection _db;
        public SecurityRepository(IConnection db)
        {
            _db = db;
        }

        public async Task<List<Sucursal>> GetCampusByUserIdAsync(string userId)
        {
            List<Sucursal> list = null;
            var parameters = new DynamicParameters();
            parameters.Add("@ACCION", "SPU", direction: ParameterDirection.Input);
            parameters.Add("@ID_USUARIO", userId, direction: ParameterDirection.Input);

            var reader = await _db.DbConnection.ExecuteReaderAsync("PA_MANT_SUCURSAL_USUARIO", parameters, commandType: CommandType.StoredProcedure);

            if (reader.FieldCount > 0)
            {
                list = new List<Sucursal>();
                while (reader.Read())
                {
                    list.Add(new Sucursal()
                    {
                        IdSucursal = reader.GetString(reader.GetOrdinal("ID_SUCURSAL")),
                        NomSucursal = reader.GetString(reader.GetOrdinal("NOM_SUCURSAL"))
                    });
                }
            }
            reader.Dispose();
            return list;
        }

        public async Task<Usuario> UserValidateAsync(string userId, string password, bool noValidar = false)
        {
            Usuario model = null;
            var parameters = new DynamicParameters();
            parameters.Add("@ID_USUARIO", userId, direction: ParameterDirection.Input);
            parameters.Add("@CLAVE", password, direction: ParameterDirection.Input);
            parameters.Add("@NO_VALIDAR", noValidar, direction: ParameterDirection.Input);

            var reader = await _db.DbConnection.ExecuteReaderAsync("PA_VALIDA_USUARIO", parameters, commandType: CommandType.StoredProcedure);

            if (reader.FieldCount > 0)
            {
                if (reader.Read())
                {
                    model = new Usuario()
                    {
                        IdUsuario = reader.GetString(reader.GetOrdinal("ID_USUARIO")),
                        NomUsuario = reader.GetString(reader.GetOrdinal("NOM_USUARIO")),
                        NomRol = reader.GetString(reader.GetOrdinal("NOM_PERFIL")),
                        Foto = reader.IsDBNull(reader.GetOrdinal("FOTO")) ? string.Empty : reader.GetString(reader.GetOrdinal("FOTO")),
                        IdSucursal = reader.IsDBNull(reader.GetOrdinal("ID_SUCURSAL")) ? string.Empty : reader.GetString(reader.GetOrdinal("ID_SUCURSAL")),
                        NomSucursal = reader.IsDBNull(reader.GetOrdinal("NOM_SUCURSAL")) ? string.Empty : reader.GetString(reader.GetOrdinal("NOM_SUCURSAL")),
                        CountSucursales = reader.GetInt32(reader.GetOrdinal("COUNT_SEDES")),
                        IdGrupoAcceso = reader.GetInt32(reader.GetOrdinal("ID_GRUPO_ACCESO")),
                        FlgCtrlTotal = reader.GetBoolean(reader.GetOrdinal("FLG_CTRL_TOTAL"))
                    };
                }
            }
            reader.Dispose();

            return model;
        }
    }
}
