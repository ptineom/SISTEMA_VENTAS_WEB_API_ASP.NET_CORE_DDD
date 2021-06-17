using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class DocCompra
	{
		public string IdSucursal { get; set; }
		public string IdTipoComprobante { get; set; }
		public string NroSerie { get; set; }
		public int NroDocumento { get; set; }
		public string IdProveedor { get; set; }
		public string IdMoneda { get; set; }
		public DateTime FecDocumento { get; set; }
		public int EstDocumento { get; set; }
		public string ObsCompra { get; set; }
		public decimal TotBruto { get; set; }
		public decimal TotDescuento { get; set; }
		public decimal TotImpuesto { get; set; }
		public decimal TotCompra { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string IdTipoPago { get; set; }
		public decimal TcCompra { get; set; }
		public string IdTipoCondicionPago { get; set; }
		public bool FlgSinCosto { get; set; }
		public decimal TasIgv { get; set; }
		public decimal TasDescuento { get; set; }
		public string JsonIngresoEgresoCaja { get; set; }
		public decimal TotCompraRedondeo { get; set; }
		public DateTime FecVencimiento { get; set; }
	}
}
