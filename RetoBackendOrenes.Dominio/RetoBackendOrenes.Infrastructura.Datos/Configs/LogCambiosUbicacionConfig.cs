using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RetoBackendOrenes.Infrastructura.Datos.Configs
{
    class LogCambiosUbicacionConfig : IEntityTypeConfiguration<LogCambiosUbicacion>
    {
        public void Configure(EntityTypeBuilder<LogCambiosUbicacion> builder)
        {
            builder.ToTable("tblConductor");
            builder.HasKey(l => l.logId);
            builder.HasOne(vehiculo => vehiculo.Vehiculo)
 
        }
    }
}
