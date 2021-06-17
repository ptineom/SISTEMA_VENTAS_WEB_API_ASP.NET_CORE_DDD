using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Almacen
	{
		public string IdAlmacen { get; set; }
		public string NomAlmacen { get; set; }
		public string IdSucursal { get; set; }
		public bool FlgPorDefecto { get; set; }
		public bool FlgAlmacenVirtual { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
