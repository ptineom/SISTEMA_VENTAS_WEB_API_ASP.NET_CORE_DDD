using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Moneda
	{
		public string IdMoneda { get; set; }
		public string NomMoneda { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string SgnMoneda { get; set; }
		public bool FlgLocal { get; set; }
	}
}
