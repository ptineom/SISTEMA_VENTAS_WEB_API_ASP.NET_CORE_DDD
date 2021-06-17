using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVentas.Domain.Entities
{
	public class Proveedor
	{
		public string IdProveedor { get; set; }
		public int IdTipoDocumento { get; set; }
		public string NroDocumento { get; set; }
		public string NomProveedor { get; set; }
		public string DirProveedor { get; set; }
		public string TelProveedor { get; set; }
		public string EmailProveedor { get; set; }
		public string IdUbigeo { get; set; }
		public string ObsProveedor { get; set; }
		public string Contacto { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public bool FlgInactivo { get; set; }
		public bool FlgMismaEmpresa { get; set; }

        //Más campos
        public string Abreviatura { get; set; }

    }
}
