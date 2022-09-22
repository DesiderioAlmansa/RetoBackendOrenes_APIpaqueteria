using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace RetoBackendOrenes.Infrastructura.Datos.Configs
{
    class VehiculoConfig : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("tblVehiculo");
            builder.HasKey(c => c.vehiculoId);

            builder
                .HasMany(p => p.Pedidos)
                .WithOne(c => c.Vehiculo);

            builder
               .HasMany(p => p.Logs_CambiosUbicacion)
               .WithOne(c => c.Vehiculo);

        }
    }
}
