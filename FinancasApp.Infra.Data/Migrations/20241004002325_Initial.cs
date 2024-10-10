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
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CATEGORIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CATEGORIA_TB_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_CONTA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DATA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    CATEGORIA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USUARIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CONTA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_CONTA_TB_CATEGORIA_CATEGORIA_ID",
                        column: x => x.CATEGORIA_ID,
                        principalTable: "TB_CATEGORIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_CONTA_TB_USUARIO_USUARIO_ID",
                        column: x => x.USUARIO_ID,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CATEGORIA_USUARIO_ID",
                table: "TB_CATEGORIA",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTA_CATEGORIA_ID",
                table: "TB_CONTA",
                column: "CATEGORIA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CONTA_USUARIO_ID",
                table: "TB_CONTA",
                column: "USUARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USUARIO_EMAIL",
                table: "TB_USUARIO",
                column: "EMAIL",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CONTA");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIA");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
