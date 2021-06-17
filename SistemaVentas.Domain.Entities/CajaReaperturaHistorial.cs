using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class CajaReaperturaHistorial
	{
		public string IdSucursal { get; set; }
		public string IdCaja { get; set; }
		public string IdUsuario { get; set; }
		public int CorrelativoCa { get; set; }
		public int Item { get; set; }
		public DateTime FechaReapertura { get; set; }
		public DateTime FechaCierreReapertura { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
