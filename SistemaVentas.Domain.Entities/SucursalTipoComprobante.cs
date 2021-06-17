using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class SucursalTipoComprobante
	{
		public string IdSucursal { get; set; }
		public string IdTipoComprobante { get; set; }
		public string NroSerie { get; set; }
		public int CorrelativoInicial { get; set; }
		public int CorrelativoFinal { get; set; }
		public int CorrelativoActual { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public bool FlgFacturacionElectronica { get; set; }
		public bool FlgEnCurso { get; set; }
	}
}
