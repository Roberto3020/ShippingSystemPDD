using Microsoft.EntityFrameworkCore.Migrations;

namespace ShippingSystemPDD.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barrio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Remitentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remitentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDePaquete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Peso = table.Column<float>(type: "real", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDePaquete", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destinarios_Direcciones_DireccionId",
                        column: x => x.DireccionId,
                        principalTable: "Direcciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDePaqueteId = table.Column<int>(type: "int", nullable: false),
                    RemitenteId = table.Column<int>(type: "int", nullable: false),
                    DestinarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paquetes_Destinarios_DestinarioId",
                        column: x => x.DestinarioId,
                        principalTable: "Destinarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquetes_Remitentes_RemitenteId",
                        column: x => x.RemitenteId,
                        principalTable: "Remitentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquetes_TiposDePaquete_TipoDePaqueteId",
                        column: x => x.TipoDePaqueteId,
                        principalTable: "TiposDePaquete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinarios_DireccionId",
                table: "Destinarios",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_DestinarioId",
                table: "Paquetes",
                column: "DestinarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_RemitenteId",
                table: "Paquetes",
                column: "RemitenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_TipoDePaqueteId",
                table: "Paquetes",
                column: "TipoDePaqueteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Destinarios");

            migrationBuilder.DropTable(
                name: "Remitentes");

            migrationBuilder.DropTable(
                name: "TiposDePaquete");

            migrationBuilder.DropTable(
                name: "Direcciones");
        }
    }
}
