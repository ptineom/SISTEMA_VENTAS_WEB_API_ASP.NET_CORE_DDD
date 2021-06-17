using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class ArticuloUm
	{
		public string IdArticulo { get; set; }
		public string IdUm { get; set; }
		public decimal NroFactor { get; set; }
		public int NroOrden { get; set; }
		public bool FlgPromocion { get; set; }
		public decimal Descuento1 { get; set; }
		public DateTime FecInicioPromocion { get; set; }
		public DateTime FecFinalPromocion { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
