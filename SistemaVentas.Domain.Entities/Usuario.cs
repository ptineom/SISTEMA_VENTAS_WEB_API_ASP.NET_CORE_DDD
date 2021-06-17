using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Usuario
	{
		public string IdUsuario { get; set; }
		public string NomUsuario { get; set; }
		public string Clave { get; set; }
		public string EmailUsuario { get; set; }
		public string IdEmpleado { get; set; }
		public int IdGrupoAcceso { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public bool FlgInactivo { get; set; }
		public string TokenRecuperacionPassword { get; set; }

        //Otros
        public string NomRol { get; set; }
        public string Foto { get; set; }
        public string IdSucursal { get; set; }
        public string NomSucursal { get; set; }
        public int CountSucursales { get; set; }
        public bool FlgCtrlTotal { get; set; }

    }
}
