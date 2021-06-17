using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class TipoCambio
	{
		public DateTime IdFecTc { get; set; }
		public string IdMoneda { get; set; }
		public decimal TcCompra { get; set; }
		public decimal TcVenta { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
