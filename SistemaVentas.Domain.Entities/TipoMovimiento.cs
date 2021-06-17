using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class TipoMovimiento
	{
		public string IdTipoMovimiento { get; set; }
		public string NomTipoMovimiento { get; set; }
		public string Movimiento { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public bool FlgCaja { get; set; }
	}
}
