using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RetoBackendOrenes.Infrastructura.Datos.Configs
{
    class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("tblCliente");
            builder.HasKey(c => c.clienteId);
        }
    }
}
