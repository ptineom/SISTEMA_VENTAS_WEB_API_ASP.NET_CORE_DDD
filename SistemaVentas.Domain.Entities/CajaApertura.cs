using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class CajaApertura
	{
		public string IdSucursal { get; set; }
		public string IdCaja { get; set; }
		public string IdUsuario { get; set; }
		public int CorrelativoCa { get; set; }
		public DateTime FechaApertura { get; set; }
		public DateTime FechaCierre { get; set; }
		public decimal MontoApertura { get; set; }
		public bool FlgCierre { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public decimal MontoCobrado { get; set; }
		public string IdMoneda { get; set; }
		public bool FlgReaperturado { get; set; }
		public bool FlgCierreDiferido { get; set; }
	}
}
