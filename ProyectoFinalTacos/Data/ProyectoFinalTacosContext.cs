using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProyectoFinalTacos.Models;

namespace ProyectoFinalTacos.Data
{
    public class ProyectoFinalTacosContext : DbContext
    {
        public ProyectoFinalTacosContext(DbContextOptions<ProyectoFinalTacosContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoFinalTacos.Models.Admin> Admin { get; set; } = default!;
        public DbSet<ProyectoFinalTacos.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<ProyectoFinalTacos.Models.Producto> Producto { get; set; } = default!;
        public DbSet<ProyectoFinalTacos.Models.Factura> Factura { get; set; } = default!;
    }
}
