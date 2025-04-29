using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncaladaD_ExamenProgreso_1.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    clienteId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    nombreCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    numeroTelefono = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    esMiembro = table.Column<bool>(type: "bit", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pagosRealizado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "PlanRecompensasCliente",
                columns: table => new
                {
                    recompensasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    puntosAcumulados = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanRecompensasCliente", x => x.recompensasId);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    reservaId = table.Column<int>(type: "int", maxLength: 15, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaEntrada = table.Column<int>(type: "int", nullable: false),
                    fechaSalida = table.Column<int>(type: "int", nullable: false),
                    valorPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    clienteId = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.reservaId);
                    table.ForeignKey(
                        name: "FK_Reserva_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_clienteId",
                table: "Reserva",
                column: "clienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanRecompensasCliente");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
