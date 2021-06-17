using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Inventario
	{
		public string IdSucursal { get; set; }
		public int NroInventario { get; set; }
		public string IdUsuarioInventario { get; set; }
		public DateTime FechaInventario { get; set; }
		public string Observacion { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public int IdEstado { get; set; }
		public string IdUsuarioAprobacion { get; set; }
		public DateTime FecAprobacion { get; set; }
		public string IdTipoInventario { get; set; }
	}
}
