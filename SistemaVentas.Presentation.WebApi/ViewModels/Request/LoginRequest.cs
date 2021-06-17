using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVentas.Presentation.WebApi.ViewModels.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Ingrese el {0}")]
        [Display(Name = "Usuario")]
        public string userId { get; set; }
        [Required(ErrorMessage = "Ingrese la {0}")]
        [Display(Name = "Contraseña")]
        public string password { get; set; }
    }
}
