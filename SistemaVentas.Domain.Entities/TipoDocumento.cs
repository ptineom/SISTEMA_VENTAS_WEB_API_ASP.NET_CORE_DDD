using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class TipoDocumento
	{
		public int IdTipoDocumento { get; set; }
		public string NomTipoDocumento { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string Abreviatura { get; set; }
		public int MaxDigitos { get; set; }
		public bool FlgRuc { get; set; }
	}
}
