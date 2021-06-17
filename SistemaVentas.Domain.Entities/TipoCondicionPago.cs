using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class TipoCondicionPago
	{
		public string IdTipoCondicionPago { get; set; }
		public string NomTipoCondicionPago { get; set; }
		public bool FlgEvaluaCredito { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
