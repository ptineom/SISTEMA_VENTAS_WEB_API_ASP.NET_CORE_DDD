using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class ConceptoMovimiento
	{
		public string IdSucursal { get; set; }
		public string IdTipoMovimiento { get; set; }
		public string IdCptoMovimiento { get; set; }
		public string IdAlmacenOrigen { get; set; }
		public string IdAlmacenDestino { get; set; }
		public string NomCptoMovimiento { get; set; }
		public int NroMovimiento { get; set; }
		public bool FlgDevolucion { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
