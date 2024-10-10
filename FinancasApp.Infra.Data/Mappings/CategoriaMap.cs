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
    /// <summary>
    /// Classe de mapeamento ORM (Mapeamento Objeto / Relacional) para a entidade Categoria
    /// </summary>
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("TB_CATEGORIA"); //nome da tabela

            builder.HasKey(c => c.Id); //chave primária

            //mapeamento dos campos da tabela
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(50).IsRequired();
            builder.Property(c => c.UsuarioId).HasColumnName("USUARIO_ID").IsRequired();

            //mapeamento das chaves estrangeiras (relacionamentos)
            builder.HasOne(c => c.Usuario) //Categoria TEM 1 Usuário
                .WithMany(u => u.Categorias) //Usuario TEM MUITAS Categorias
                .HasForeignKey(c => c.UsuarioId) //Chave estrangeira do relacionamento
                .OnDelete(DeleteBehavior.Restrict); //Não permite exclusão em cascata
        }
    }
}
