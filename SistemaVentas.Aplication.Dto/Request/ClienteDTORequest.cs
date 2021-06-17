using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.Aplication.DTO.Request
{
    public class ClienteDTORequest
    {
		public string IdCliente { get; set; }
		public int IdTipoDocumento { get; set; }
		public string NroDocumento { get; set; }
		public string NomCliente { get; set; }
		public string DirCliente { get; set; }
		public string TelCliente { get; set; }
		public string EmailCliente { get; set; }
		public string IdUbigeo { get; set; }
		public string ObsCliente { get; set; }
		public bool FlgPersonaNatural { get; set; }
		public string Sexo { get; set; }
		public string ApellidoPaterno { get; set; }
		public string ApellidoMaterno { get; set; }
		public string Nombres { get; set; }
		public string Contacto { get; set; }
		public bool FlgInactivo { get; set; }
		public string IdUsuarioRegistro { get; set; }
		public bool FlgPublicoEnGeneral { get; set; }

		//otros
		public string Abreviatura { get; set; }
	}
}
