using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTacos.Models
{
    public class Usuario 
    {
        [Key]
        public int IDUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string CedulaUsuario { get; set; }

        [Required]
        [MinLength (10), MaxLength (10)]
        public string NumeroUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string CorreoUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string ContraseñaUsuario { get; set; }
    }
}
