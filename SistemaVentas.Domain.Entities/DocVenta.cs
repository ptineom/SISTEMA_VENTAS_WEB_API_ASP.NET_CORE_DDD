using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class DocVenta
	{
		public string IdSucursal { get; set; }
		public string IdTipoComprobante { get; set; }
		public string NroSerie { get; set; }
		public int NroDocumento { get; set; }
		public string IdCliente { get; set; }
		public string IdTipoCondicionPago { get; set; }
		public string IdMoneda { get; set; }
		public DateTime FecDocumento { get; set; }
		public int EstDocumento { get; set; }
		public decimal TotBruto { get; set; }
		public decimal TotDescuento { get; set; }
		public decimal TotImpuesto { get; set; }
		public decimal TotVenta { get; set; }
		public string ObsVenta { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string IdTipoPago { get; set; }
		public decimal TcVenta { get; set; }
		public decimal TasDescuento { get; set; }
		public string IdCajaCa { get; set; }
		public string IdUsuarioCa { get; set; }
		public int CorrelativoCa { get; set; }
		public bool FlgImpreso { get; set; }
		public string IdSucursalRef { get; set; }
		public string IdTipoComprobanteRef { get; set; }
		public string NroSerieRef { get; set; }
		public int NroDocumentoRef { get; set; }
		public string IdTipoNc { get; set; }
		public string MotivoNc { get; set; }
		public DateTime FecVencimiento { get; set; }
		public decimal TotVentaRedondeo { get; set; }
		public bool FlgDiferido { get; set; }
	}
}
