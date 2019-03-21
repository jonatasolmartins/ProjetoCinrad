using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinrad.Infrastructure.Migrations.Cinrad
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgendaProducao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaProducao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApresentacaoProduto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApresentacaoProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    codigo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(maxLength: 100, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(maxLength: 20, nullable: true),
                    Site = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descrisao = table.Column<string>(nullable: true),
                    IsDadosObrigatorio = table.Column<bool>(nullable: false),
                    CodigoCor = table.Column<Guid>(nullable: false),
                    UnidadeMedida = table.Column<string>(nullable: true),
                    UnidadeVenda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportadora",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    codigo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnpj = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(maxLength: 100, nullable: false),
                    NomeFantasia = table.Column<string>(maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(maxLength: 20, nullable: true),
                    Site = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 35, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Celular = table.Column<string>(maxLength: 9, nullable: true),
                    Telefone = table.Column<string>(maxLength: 8, nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true),
                    TransportadoraId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Transportadora_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ClienteId",
                table: "Usuario",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TransportadoraId",
                table: "Usuario",
                column: "TransportadoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaProducao");

            migrationBuilder.DropTable(
                name: "ApresentacaoProduto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Transportadora");
        }
    }
}
