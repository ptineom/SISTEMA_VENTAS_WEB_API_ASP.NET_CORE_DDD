using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class ConceptoIECaja
	{
		public string IdConceptoIE { get; set; }
		public string NomConceptoIE { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string IdTipoMovimiento { get; set; }
		public bool FlgPagoProveedores { get; set; }
	}
}
