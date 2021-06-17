using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class GrupoAcceso
	{
		public int IdGrupoAcceso { get; set; }
		public string NomGrupoAcceso { get; set; }
		public string ObsGrupoAcceso { get; set; }
		public bool FlgCtrlTotal { get; set; }
		public string IdUsuarioRegistro { get; set; }
	}
}
