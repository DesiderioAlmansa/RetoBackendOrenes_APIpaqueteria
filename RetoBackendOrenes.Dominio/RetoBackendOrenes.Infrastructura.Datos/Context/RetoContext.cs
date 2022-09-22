using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using Microsoft.EntityFrameworkCore;
using RetoBackendOrenes.Infrastructura.Datos.Configs;

namespace RetoBackendOrenes.Infrastructura.Datos.Context
{
    public class RetoContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Conductor> Conductor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<LogCambiosUbicacion> LogCambiosUbicacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Initial Catalog=retoBackendOrenes;Integrated Security = True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ClienteConfig());
            builder.ApplyConfiguration(new ConductorConfig());
            builder.ApplyConfiguration(new PedidoConfig());
            builder.ApplyConfiguration(new VehiculoConfig());
            builder.ApplyConfiguration(new LogCambiosUbicacionConfig());

        }

    }
}
