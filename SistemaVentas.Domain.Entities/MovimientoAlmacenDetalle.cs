using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class MovimientoAlmacenDetalle
	{
		public string IdSucursal { get; set; }
		public string IdTipoMovimiento { get; set; }
		public string IdCptoMovimiento { get; set; }
		public int NroMovimiento { get; set; }
		public string IdArticulo { get; set; }
		public decimal Cantidad { get; set; }
		public decimal NroFactor { get; set; }
		public string IdUm { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
