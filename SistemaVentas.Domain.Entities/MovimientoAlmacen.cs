using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class MovimientoAlmacen
	{
		public string IdSucursal { get; set; }
		public string IdTipoMovimiento { get; set; }
		public string IdCptoMovimiento { get; set; }
		public int NroMovimiento { get; set; }
		public DateTime FecMovimiento { get; set; }
		public int EstMovimiento { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string IdTipoComprobanteRef { get; set; }
		public string NroSerieRef { get; set; }
		public int NroDocumentoRef { get; set; }
		public string IdProveedorRef { get; set; }
	}
}
