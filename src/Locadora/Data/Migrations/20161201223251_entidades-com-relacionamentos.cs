using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Locadora.Data.Migrations
{
    public partial class entidadescomrelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: true),
                    DataAdesao = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    _statusCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pais = table.Column<string>(nullable: true),
                    DataEstreia = table.Column<DateTime>(nullable: false),
                    DataUltimoFilme = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataEstreia = table.Column<DateTime>(nullable: false),
                    DiretorId = table.Column<int>(nullable: false),
                    EstudioId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    NumPremios = table.Column<int>(nullable: false),
                    Idioma = table.Column<string>(nullable: true),
                    _genero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filme_Diretor_DiretorId",
                        column: x => x.DiretorId,
                        principalTable: "Diretor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filme_Estudio_EstudioId",
                        column: x => x.EstudioId,
                        principalTable: "Estudio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Midia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilmeId = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false),
                    Idioma = table.Column<string>(nullable: true),
                    Legenda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Midia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Midia_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: false),
                    MidiaId = table.Column<int>(nullable: true),
                    _statusEmprestimo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Midia_MidiaId",
                        column: x => x.MidiaId,
                        principalTable: "Midia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_ClienteId",
                table: "Emprestimo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_MidiaId",
                table: "Emprestimo",
                column: "MidiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_DiretorId",
                table: "Filme",
                column: "DiretorId");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_EstudioId",
                table: "Filme",
                column: "EstudioId");

            migrationBuilder.CreateIndex(
                name: "IX_Midia_FilmeId",
                table: "Midia",
                column: "FilmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Midia");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Estudio");
        }
    }
}
