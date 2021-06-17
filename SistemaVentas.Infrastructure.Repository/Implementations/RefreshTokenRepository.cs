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
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly IConnection _db;
        private readonly string _storeProcedure = "PA_MANT_REFRESH_TOKEN";
        public RefreshTokenRepository(IConnection db)
        {
            _db = db;
        }

        public async Task<bool> RegisterAsync(RefreshToken obj, IDbTransaction transaction = null)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "INS", direction: ParameterDirection.Input);
            parameters.Add("@ID_REFRESH_TOKEN", obj.IdRefreshToken, direction: ParameterDirection.Input);
            parameters.Add("@TIEMPO_EXPIRACION_MINUTOS", obj.TiempoExpiracionMinutos, direction: ParameterDirection.Input);
            parameters.Add("@ID_USUARIO_TOKEN", obj.IdUsuarioToken, direction: ParameterDirection.Input);
            parameters.Add("@IP_ADDRESS", obj.IpAddress, direction: ParameterDirection.Input);
            parameters.Add("@ID_USUARIO_REGISTRO", obj.IdUsuarioRegistro, direction: ParameterDirection.Input);
            parameters.Add("@FEC_CREACION_UTC", obj.FecCreacionUtc, direction: ParameterDirection.Input);
            parameters.Add("@JSON_CLAIMS", obj.JsonClaims, direction: ParameterDirection.Input);

            await _db.DbConnection.ExecuteAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure, transaction: transaction);

            return true;
        }
        public async Task<RefreshToken> GetByIdAsync(string idRefreshToken)
        {
            RefreshToken model = null;
            var parameters = new DynamicParameters();

            parameters.Add("@ACCION", "GET", direction: ParameterDirection.Input);
            parameters.Add("@ID_REFRESH_TOKEN", idRefreshToken, direction: ParameterDirection.Input);

            var reader = await _db.DbConnection.ExecuteReaderAsync(_storeProcedure, parameters, commandType: CommandType.StoredProcedure);

            if (reader.FieldCount > 0)
            {
                if (reader.Read())
                {
                    model = new RefreshToken()
                    {
                        IdRefreshToken = reader.GetString(reader.GetOrdinal("ID_REFRESH_TOKEN")),
                        FecCreacionUtc = reader.GetDateTime(reader.GetOrdinal("FEC_CREACION_UTC")),
                        FecExpiracionUtc = reader.GetDateTime(reader.GetOrdinal("FEC_EXPIRACION_UTC")),
                        IdUsuarioToken = reader.GetString(reader.GetOrdinal("ID_USUARIO_TOKEN")),
                        JsonClaims = reader.GetString(reader.GetOrdinal("JSON_CLAIMS"))
                    };
                }
            }
            return model;
        }
    }
}
