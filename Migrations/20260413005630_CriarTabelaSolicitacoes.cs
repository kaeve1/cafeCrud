using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudCafeteria.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaSolicitacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeMaquina = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Localizacao = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DescricaoProblema = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Prioridade = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitacoes");
        }
    }
}
