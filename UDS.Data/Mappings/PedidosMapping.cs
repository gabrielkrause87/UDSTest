using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Model;

namespace UDS.Data.Mappings
{
    class PedidosMapping : IEntityTypeConfiguration<Pedidos>
    {
        public void Configure(EntityTypeBuilder<Pedidos> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.TempoSabor)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.TempoTamanho)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.ValorSabor)
                .IsRequired()
                .HasColumnType("float");

            builder.Property(c => c.ValorTamanho)
                .IsRequired()
                .HasColumnType("float");

            builder.Property(c => c.Cliente)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(c => c.DtPedido)
                .IsRequired()
                .HasColumnType("datetime");

            //builder.HasOne(f => f.Sabores)
                //.WithOne(e => e.Pedidos);

            //builder.HasOne(f => f.Tamanhos)
                //.WithOne(e => e.Pedidos);

            builder.HasMany(f => f.PedidosPersonalizacoes)
                .WithOne(p => p.Pedidos)
                .HasForeignKey(p => p.PedidosId);

            builder.ToTable("Pedidos");
        }
    }
}
