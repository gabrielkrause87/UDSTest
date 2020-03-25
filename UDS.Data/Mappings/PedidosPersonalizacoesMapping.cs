using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Model;

namespace UDS.Data.Mappings
{
    public class PedidosPersonalizacoesMapping : IEntityTypeConfiguration<PedidosPersonalizacoes>
    {
        public void Configure(EntityTypeBuilder<PedidosPersonalizacoes> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.TempoPersonalizacao)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.ValorPersonalizacao)
                .IsRequired()
                .HasColumnType("float");

            builder.HasOne(p => p.Personalizacoes)
                .WithOne(e => e.PedidosPersonalizacoes);

            builder.ToTable("PedidosPersonalizacoes");
        }
    }
}
