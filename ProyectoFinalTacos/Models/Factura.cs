using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTacos.Models
{
    public class Factura
    {
        [Key]
        public int IDFactura { get; set; }

        public int IDUsuario { get; set; }

        public int IDProducto { get; set; }

        [ForeignKey("IDUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IDProducto")]
        public Producto Producto { get; set; }

        [Required]
        public DateTime FechaEmision { get; set; }
    }
}
