using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class ArticuloAlmacen
	{
		public string IdArticulo { get; set; }
		public string IdAlmacen { get; set; }
		public decimal StockActual { get; set; }
		public decimal StockMinimo { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
