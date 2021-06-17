using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Pagos
	{
		public string IdSucursal { get; set; }
		public string IdTipoComprobante { get; set; }
		public string NroSerie { get; set; }
		public int NroDocumento { get; set; }
		public string IdProveedor { get; set; }
		public int Correlativo { get; set; }
		public string IdTipoPago { get; set; }
		public string IdMoneda { get; set; }
		public decimal TotCobranza { get; set; }
		public DateTime FecCobranza { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string XmlIngresoEgresoCaja { get; set; }
		public DateTime FecCancelacion { get; set; }
	}
}
