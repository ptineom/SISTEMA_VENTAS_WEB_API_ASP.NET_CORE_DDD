using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Empleado
	{
		public string IdEmpleado { get; set; }
		public int IdCargo { get; set; }
		public int IdTipoDocumento { get; set; }
		public string NumDocumento { get; set; }
		public string ApellidoPaterno { get; set; }
		public string ApellidoMaterno { get; set; }
		public string Nombres { get; set; }
		public string Direccion { get; set; }
		public string Email { get; set; }
		public DateTime FecEntrante { get; set; }
		public DateTime FecCese { get; set; }
		public bool FlgInactivo { get; set; }
		public string IdUbigeo { get; set; }
		public string Sexo { get; set; }
		public string Foto { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public string Telefono { get; set; }
	}
}
