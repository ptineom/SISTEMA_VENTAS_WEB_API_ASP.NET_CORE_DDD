using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Fotos
	{
		public int IdTipoFoto { get; set; }
		public string IdElemento { get; set; }
		public string Foto1 { get; set; }
		public string Foto2 { get; set; }
		public string Foto3 { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
