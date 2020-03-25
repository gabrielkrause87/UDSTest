using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Model;

namespace UDS.Data.Mappings
{
    public class PersonalizacoesMapping : IEntityTypeConfiguration<Personalizacoes>
    {
        public void Configure(EntityTypeBuilder<Personalizacoes> builder)
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

            builder.ToTable("Personalizacoes");
        }
    }
}
