using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.Aplication.DTO.Response
{
    public class RefreshTokenDTOResponse
    {
		public string IdRefreshToken { get; set; }
		public string IdUsuarioToken { get; set; }
		public DateTime FecCreacionUtc { get; set; }
		public DateTime FecExpiracionUtc { get; set; }
		public int TiempoExpiracionMinutos { get; set; }
		public string IpAddress { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string JsonClaims { get; set; }
	}
}
