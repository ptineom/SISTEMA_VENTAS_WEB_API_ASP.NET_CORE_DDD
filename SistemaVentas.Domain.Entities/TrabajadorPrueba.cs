using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class TrabajadorPrueba
	{
		public string IdTrabajador { get; set; }
		public string ApellidoPaterno { get; set; }
		public string ApellidoMaterno { get; set; }
		public string Nombres { get; set; }
		public int Hijos { get; set; }
		public decimal Sueldo { get; set; }
		public DateTime FechaNacimiento { get; set; }
	}
}
