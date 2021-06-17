using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Aplicacion
	{
		public int IdAplicacion { get; set; }
		public string NomAplicacion { get; set; }
		public string ObsAplicacion { get; set; }
		public int IdAplicacionPadre { get; set; }
		public bool FlgFormulario { get; set; }
		public string NomFormulario { get; set; }
		public bool FlgEjecutable { get; set; }
		public string NomControlador { get; set; }
		public string NomImg { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public bool FlgAccesoDirecto { get; set; }
		public string BgColor { get; set; }
		public string IconSpa { get; set; }
		public string RouteSpa { get; set; }
		public bool FlgRequiereAperturaCaja { get; set; }
	}
}
