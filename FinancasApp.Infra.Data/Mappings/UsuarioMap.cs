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
    /// Classe de mapeamento ORM (Mapeamento Objeto / Relacional) para a entidade Usuário
    /// </summary>
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO"); //nome da tabela

            builder.HasKey(u => u.Id); //chave primária

            //mapeamento dos campos da tabela
            builder.Property(u => u.Id).HasColumnName("ID");
            builder.Property(u => u.Nome).HasColumnName("NOME").HasMaxLength(150).IsRequired();
            builder.Property(u => u.Email).HasColumnName("EMAIL").HasMaxLength(50).IsRequired();
            builder.Property(u => u.Senha).HasColumnName("SENHA").HasMaxLength(100).IsRequired();

            //definindo os campos UNIQUE da tabela
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
