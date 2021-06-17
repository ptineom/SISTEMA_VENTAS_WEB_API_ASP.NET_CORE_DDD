using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVentas.Aplication.DTO.Response
{
    public class UsuarioAuthDTOResponse
    {
        public string IdUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string NomRol { get; set; }
        public string Foto { get; set; }
        public string IdSucursal { get; set; }
        public string NomSucursal { get; set; }
        public int CountSucursales { get; set; }
        public bool FlgCtrlTotal { get; set; }
        public int IdGrupoAcceso { get; set; }
    }
}
