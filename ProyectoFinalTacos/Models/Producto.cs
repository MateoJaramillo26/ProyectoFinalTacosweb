using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTacos.Models
{
    public class Producto
    {
        [Key]
        public int IDProducto { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreProducto { get; set; }

        [Required]
        [StringLength(500)]
        public string DescripcionProducto { get; set; }
        [Required]
        [StringLength(500)]
        public string ImagenProducto { get; set; }
    }
}
