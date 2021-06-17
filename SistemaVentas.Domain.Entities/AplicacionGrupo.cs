using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class AplicacionGrupo
	{
		public int IdGrupoAcceso { get; set; }
		public int IdAplicacion { get; set; }
		public bool FlgNuevo { get; set; }
		public bool FlgModificacion { get; set; }
		public bool FlgAnulacion { get; set; }
		public bool FlgReporte { get; set; }
		public bool FlgAprobacion { get; set; }
		public bool FlgCierre { get; set; }
		public bool FlgReapertura { get; set; }
		public bool FlgExportar { get; set; }
		public bool FlgImportar { get; set; }
	}
}
