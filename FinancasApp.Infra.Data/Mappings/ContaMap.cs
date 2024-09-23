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
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.ToTable("CONTA"); //nome da tabela

            builder.HasKey(c => c.Id); //chave primária

            builder.Property(c => c.Id) //campo 'Id'
                .HasColumnName("ID"); //nome da coluna

            builder.Property(c => c.Nome) //campo 'Nome'
                .HasColumnName("NOME") //nome da coluna
                .HasMaxLength(100) //tamanho máximo
                .IsRequired(); //obrigatório

            builder.Property(c => c.Data) //campo 'Data'
                .HasColumnName("DATA") //nome da coluna
                .HasColumnType("date") //tipo do campo no banco de dados
                .IsRequired(); //obrigatório

            builder.Property(c => c.Valor) //campo 'Valor'
                .HasColumnName("VALOR") //nome da coluna
                .HasColumnType("decimal(18,2)") //tipo do campo no banco de dados
                .IsRequired(); //obrigatório

            builder.Property(c => c.Tipo) //campo 'Tipo'
                .HasColumnName("TIPO") //nome da coluna
                .IsRequired(); //obrigatório

            builder.Property(c => c.UsuarioId) //campo 'UsuarioId'
                .HasColumnName("USUARIO_ID"); //nome da coluna

            //mapeamento do relacionamento (1 para muitos)
            builder.HasOne(c => c.Usuario) //Conta TEM 1 Usuário
                .WithMany(u => u.Contas) //Usuário TEM Muitas Contas
                .HasForeignKey(c => c.UsuarioId) //chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //não excluir se houverem registros vinculados
        }
    }
}
