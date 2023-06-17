using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDRXTransports.Migrations
{
    public partial class GateCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GateModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GateModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GateModel_LocationModel_LocationModelId",
                        column: x => x.LocationModelId,
                        principalTable: "LocationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GateModel_LocationModelId",
                table: "GateModel",
                column: "LocationModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GateModel");
        }
    }
}
