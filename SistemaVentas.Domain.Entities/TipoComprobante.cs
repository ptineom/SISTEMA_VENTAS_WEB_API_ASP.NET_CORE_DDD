using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class TipoComprobante
	{
		public string IdTipoComprobante { get; set; }
		public string NomTipoComprobante { get; set; }
		public bool FlgVenta { get; set; }
		public bool FlgCompra { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public bool FlgRendirSunat { get; set; }
		public bool FlgNoEditable { get; set; }
		public string JsonTipoNc { get; set; }
		public string LetraInicialSerieElectronica { get; set; }
	}
}
