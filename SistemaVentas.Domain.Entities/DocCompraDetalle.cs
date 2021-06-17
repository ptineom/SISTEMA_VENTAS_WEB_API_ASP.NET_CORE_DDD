using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class DocCompraDetalle
	{
		public string IdSucursal { get; set; }
		public string IdTipoComprobante { get; set; }
		public string NroSerie { get; set; }
		public int NroDocumento { get; set; }
		public string IdProveedor { get; set; }
		public string IdArticulo { get; set; }
		public string IdAlmacen { get; set; }
		public decimal Cantidad { get; set; }
		public string IdUm { get; set; }
		public decimal NroFactor { get; set; }
		public decimal PrecioArticulo { get; set; }
		public decimal Importe { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public decimal TasDescuento { get; set; }
		public decimal PrecioCompra { get; set; }
	}
}
