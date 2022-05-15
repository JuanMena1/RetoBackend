using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RetoBackend.Modelos;

namespace RetoBackend.Data
{
    public class RetoBackendContext : DbContext
    {
        public RetoBackendContext (DbContextOptions<RetoBackendContext> options)
            : base(options)
        {
        }

        public DbSet<RetoBackend.Modelos.Vehiculo>? Vehiculo { get; set; }
        public DbSet<RetoBackend.Modelos.Pedido>? Pedido { get; set; }
    }
}
