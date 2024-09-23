using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancasApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "USUARIO_ID",
                table: "CONTA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USUARIO_ID",
                table: "CATEGORIA",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CONTA_USUARIO_ID",
                table: "CONTA",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIA_USUARIO_ID",
                table: "CATEGORIA",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_EMAIL",
                table: "USUARIO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CATEGORIA_USUARIO_USUARIO_ID",
                table: "CATEGORIA",
                column: "USUARIO_ID",
                principalTable: "USUARIO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CONTA_USUARIO_USUARIO_ID",
                table: "CONTA",
                column: "USUARIO_ID",
                principalTable: "USUARIO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CATEGORIA_USUARIO_USUARIO_ID",
                table: "CATEGORIA");

            migrationBuilder.DropForeignKey(
                name: "FK_CONTA_USUARIO_USUARIO_ID",
                table: "CONTA");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_CONTA_USUARIO_ID",
                table: "CONTA");

            migrationBuilder.DropIndex(
                name: "IX_CATEGORIA_USUARIO_ID",
                table: "CATEGORIA");

            migrationBuilder.DropColumn(
                name: "USUARIO_ID",
                table: "CONTA");

            migrationBuilder.DropColumn(
                name: "USUARIO_ID",
                table: "CATEGORIA");
        }
    }
}
