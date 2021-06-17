using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class IngresoEgresoCaja
	{
		public string IdSucursal { get; set; }
		public string IdTipoMovimiento { get; set; }
		public string IdIECaja { get; set; }
		public decimal Importe { get; set; }
		public string IdConceptoIE { get; set; }
		public string Detalle { get; set; }
		public DateTime FechaIE { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string IdCajaCa { get; set; }
		public int CorrelativoCa { get; set; }
		public string IdUsuarioCa { get; set; }
		public string IdMoneda { get; set; }
		public bool FlgAutomatico { get; set; }
	}
}
