using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTacos.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string CorreoUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ContraseñaUsuario { get; set; }
    }
}
