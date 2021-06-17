using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class InventarioDetalle
	{
		public string IdSucursal { get; set; }
		public int NroInventario { get; set; }
		public string IdArticulo { get; set; }
		public decimal StockVirtual { get; set; }
		public decimal StockFisico { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string IdUm { get; set; }
		public decimal NroFactor { get; set; }
	}
}
