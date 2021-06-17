using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Cargo
	{
		public int IdCargo { get; set; }
		public string NomCargo { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string Abreviatura { get; set; }
	}
}
