using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class UnidadMedida
	{
		public string IdUm { get; set; }
		public string NomUm { get; set; }
		public bool FlgMedidaPeso { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string Abreviado { get; set; }
	}
}
