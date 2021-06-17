using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Articulo
	{
		public string IdArticulo { get; set; }
		public string NomArticulo { get; set; }
		public string NomVenta { get; set; }
		public bool FlgImportado { get; set; }
		public int IdMarca { get; set; }
		public decimal PrecioCompra { get; set; }
		public bool FlgInactivo { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string IdLinea { get; set; }
		public string IdGrupo { get; set; }
		public string IdFamilia { get; set; }
		public string CodigoBarra { get; set; }
		public decimal PrecioVenta { get; set; }
	}
}
