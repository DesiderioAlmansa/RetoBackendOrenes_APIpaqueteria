using System;
using System.Collections.Generic;
using System.Text;

using RetoBackendOrenes.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RetoBackendOrenes.Infrastructura.Datos.Configs
{
    class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("tblPedido");
            builder.HasKey(c => c.numeroPedido);

            //builder
            //    .HasMany(p => p.Pedidos)
            //    .WithOne(c => c.Cliente);


        }
    }
}
