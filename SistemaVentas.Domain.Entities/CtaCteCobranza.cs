using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class CtaCteCobranza
	{
		public string IdSucursal { get; set; }
		public string IdTipoComprobante { get; set; }
		public string NroSerie { get; set; }
		public int NroDocumento { get; set; }
		public string IdCliente { get; set; }
		public decimal TotCobranza { get; set; }
		public decimal TotSaldo { get; set; }
		public DateTime FecDocumento { get; set; }
		public DateTime FecVencimiento { get; set; }
		public bool FlgEvaluaCredito { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string IdMoneda { get; set; }
	}
}
