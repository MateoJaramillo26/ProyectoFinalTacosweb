using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

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

        [Required]
        [Range(0,15)]
        public decimal PrecioProducto { get; set; }
    }
}
