using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.Aplication.DTO.Response
{
    public class SucursalDTOResponse
    {
		public string IdSucursal { get; set; }
		public string NomSucursal { get; set; }
		public string IdEmpresa { get; set; }
		public string Direccion { get; set; }
		public string IdUbigeo { get; set; }
		public bool FlgPrincipal { get; set; }
		public string Email { get; set; }
		public int NroIngresoDirecto { get; set; }
		public string JsonTelefonos { get; set; }
	}
}
