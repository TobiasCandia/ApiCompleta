using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCompleta.Migrations
{
    /// <inheritdoc />
    public partial class AgregarNumeroVillaTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Amenidad",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "NuemeroVillas",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    DetalleEspecial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NuemeroVillas", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_NuemeroVillas_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion", "Tarifa" },
                values: new object[] { new DateTime(2023, 6, 29, 11, 34, 59, 872, DateTimeKind.Local).AddTicks(4796), new DateTime(2023, 6, 29, 11, 34, 59, 872, DateTimeKind.Local).AddTicks(4785), 20.0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion", "Tarifa" },
                values: new object[] { new DateTime(2023, 6, 29, 11, 34, 59, 872, DateTimeKind.Local).AddTicks(4799), new DateTime(2023, 6, 29, 11, 34, 59, 872, DateTimeKind.Local).AddTicks(4798), 10.0 });

            migrationBuilder.CreateIndex(
                name: "IX_NuemeroVillas_VillaId",
                table: "NuemeroVillas",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NuemeroVillas");

            migrationBuilder.AlterColumn<string>(
                name: "ImagenUrl",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Amenidad",
                table: "Villas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizacion", "FechaCreacion", "Tarifa" },
                values: new object[] { new DateTime(2023, 6, 27, 10, 28, 19, 781, DateTimeKind.Local).AddTicks(1425), new DateTime(2023, 6, 27, 10, 28, 19, 781, DateTimeKind.Local).AddTicks(1413), 200.0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizacion", "FechaCreacion", "Tarifa" },
                values: new object[] { new DateTime(2023, 6, 27, 10, 28, 19, 781, DateTimeKind.Local).AddTicks(1428), new DateTime(2023, 6, 27, 10, 28, 19, 781, DateTimeKind.Local).AddTicks(1428), 150.0 });
        }
    }
}
