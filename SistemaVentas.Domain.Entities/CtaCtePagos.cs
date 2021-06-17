using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class CtaCtePagos
	{
		public string IdSucursal { get; set; }
		public string IdTipoComprobante { get; set; }
		public string NroSerie { get; set; }
		public int NroDocumento { get; set; }
		public string IdProveedor { get; set; }
		public string IdMoneda { get; set; }
		public decimal TotPago { get; set; }
		public decimal TotSaldo { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public bool FlgEvaluaCredito { get; set; }
		public DateTime FecCancelacion { get; set; }
	}
}
