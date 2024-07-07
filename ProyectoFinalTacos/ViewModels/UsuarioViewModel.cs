using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTacos.ViewModels
{
    public class UsuarioViewModel
    {
        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string CedulaUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string NumeroUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string CorreoUsuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ContraseñaUsuario { get; set; }
    }
}
