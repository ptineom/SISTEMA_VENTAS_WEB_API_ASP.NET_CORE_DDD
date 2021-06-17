using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class SucursalCajaUsuario
	{
		public string IdSucursal { get; set; }
		public string IdCaja { get; set; }
		public string IdUsuario { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public bool FlgInactivo { get; set; }
	}
}
