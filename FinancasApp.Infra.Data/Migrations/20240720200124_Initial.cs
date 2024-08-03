using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancasApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONTA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TIPO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTA", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTA");
        }
    }
}
