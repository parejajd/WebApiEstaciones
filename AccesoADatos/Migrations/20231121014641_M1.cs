using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoADatos.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstacionDeServicio",
                columns: table => new
                {
                    EstacionDeServicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstaAbierta = table.Column<bool>(type: "bit", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstacionDeServicio", x => x.EstacionDeServicioId);
                });

            migrationBuilder.CreateTable(
                name: "Combustible",
                columns: table => new
                {
                    CombustibleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCombustible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoGalon = table.Column<double>(type: "float", nullable: false),
                    EstacionDeServicioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustible", x => x.CombustibleId);
                    table.ForeignKey(
                        name: "FK_Combustible_EstacionDeServicio_EstacionDeServicioId",
                        column: x => x.EstacionDeServicioId,
                        principalTable: "EstacionDeServicio",
                        principalColumn: "EstacionDeServicioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combustible_EstacionDeServicioId",
                table: "Combustible",
                column: "EstacionDeServicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combustible");

            migrationBuilder.DropTable(
                name: "EstacionDeServicio");
        }
    }
}
