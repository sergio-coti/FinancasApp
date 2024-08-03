using FinancasApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Mappings
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("CONTA");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Data).HasColumnName("DATA").IsRequired();
            builder.Property(c => c.Valor).HasColumnName("VALOR").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(c => c.Descricao).HasColumnName("DESCRICAO").HasMaxLength(250).IsRequired();
            builder.Property(c => c.Tipo).HasColumnName("TIPO").IsRequired();
        }
    }
}
