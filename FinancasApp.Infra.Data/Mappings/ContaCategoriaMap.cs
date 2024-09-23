using FinancasApp.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Data.Mappings
{
    public class ContaCategoriaMap : IEntityTypeConfiguration<ContaCategoria>
    {
        public void Configure(EntityTypeBuilder<ContaCategoria> builder)
        {
            builder.ToTable("CONTA_CATEGORIA"); //nome da tabela

            builder.HasKey(c => new { c.ContaId, c.CategoriaId }); //chave primária composta

            builder.Property(c => c.ContaId) //campo 'ContaId'
                .HasColumnName("CONTA_ID"); //nome da coluna

            builder.Property(c => c.CategoriaId) //campo 'CategoriaId'
                .HasColumnName("CATEGORIA_ID"); //nome da coluna

            builder.HasOne(c => c.Conta) //ContaCategoria TEM 1 Conta
                .WithMany(c => c.ContaCategoria) //Conta TEM MUITAS ContaCategoria
                .HasForeignKey(c => c.ContaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //Não permitir exclusão caso haja vínculo

            builder.HasOne(c => c.Categoria) //ContaCategoria TEM 1 Categoria
                .WithMany(c => c.ContaCategoria) //Categoria TEM MUITAS ContaCategoria
                .HasForeignKey(c => c.CategoriaId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //Não permitir exclusão caso haja vinculo
        }
    }
}
