using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Empresa
	{
		public string IdEmpresa { get; set; }
		public string NomEmpresa { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string LogoEmpresa { get; set; }
		public decimal Igv { get; set; }
		public string NumeroRuc { get; set; }
		public decimal StockMinimo { get; set; }
		public decimal MontoBoletaObligatorioCliente { get; set; }
	}
}
