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
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA"); //nome da tabela

            builder.HasKey(c => c.Id); //chave primária

            builder.Property(c => c.Id) //campo 'Id'
                .HasColumnName("ID"); //nome do campo

            builder.Property(c => c.Nome) //campo 'Nome'
                .HasColumnName("NOME") //nome do campo
                .HasMaxLength(50) //máximo de caracteres
                .IsRequired(); //obrigatório

            builder.Property(c => c.UsuarioId) //campo 'UsuarioId'
                .HasColumnName("USUARIO_ID");

            //mapeamento de relacionamento 1 para muitos
            builder.HasOne(c => c.Usuario) //Categoria TEM 1 Usuário
                .WithMany(u => u.Categorias) //Usuário TEM Muitas Categorias
                .HasForeignKey(c => c.UsuarioId) //Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //não permitir a exclusão caso hajam registros vinculados
        }
    }
}
