using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinrad.Infrastructure.Migrations.Cinrad
{
    public partial class AddClienteTransportadora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Transportadora",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Cliente",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ClienteTransportadora",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    TransportadoraId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteTransportadora", x => new { x.ClienteId, x.TransportadoraId });
                    table.ForeignKey(
                        name: "FK_ClienteTransportadora_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteTransportadora_Transportadora_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteTransportadora_TransportadoraId",
                table: "ClienteTransportadora",
                column: "TransportadoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteTransportadora");

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Transportadora",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);

            migrationBuilder.AlterColumn<string>(
                name: "Cnpj",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14);
        }
    }
}
