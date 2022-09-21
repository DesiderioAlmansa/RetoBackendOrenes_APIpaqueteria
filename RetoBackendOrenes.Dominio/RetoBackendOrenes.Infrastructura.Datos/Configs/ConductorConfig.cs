using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RetoBackendOrenes.Infrastructura.Datos.Configs
{
    class ConductorConfig : IEntityTypeConfiguration<Conductor>
    {
        public void Configure(EntityTypeBuilder<Conductor> builder)
        {
            builder.ToTable("tblConductor");
            builder.HasKey(c => c.conductorId);
        }
    }
}
