using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalTacos.Models
{
    public class Admin
    {
        [Key]
        public int IDAdmin { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreAdmin { get; set; }

        [Required]
        [StringLength(10)]
        public string CedulaAdmin { get; set; }

        [Required]
        [StringLength(10)]
        public string NumeroTelef { get; set; }

        [Required]
        [StringLength(100)]
        public string CorreoAdmin { get; set; }

        [Required]
        [StringLength(100)]
        public string ContraseñaAdmin { get; set; }
    }
}
