using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Model;

namespace UDS.Data.Mappings
{
    class SaboresMapping : IEntityTypeConfiguration<Sabores>
    {
        public void Configure(EntityTypeBuilder<Sabores> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.Valor)
                .IsRequired()
                .HasColumnType("float");

            builder.Property(c => c.TempoPreparo)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(c => c.Ativo)
                .IsRequired()
                .HasColumnType("bit");

            builder.HasMany(p => p.Pedidos)
                .WithOne(x => x.Sabores)
                .HasForeignKey(x => x.SaboresId);

            builder.ToTable("Sabores");
        }
    }
}
