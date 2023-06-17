using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDRXTransports.Migrations
{
    public partial class RemovedReqFromLocIDAdm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraTest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TraTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverModelId = table.Column<int>(type: "int", nullable: false),
                    LocationModelId = table.Column<int>(type: "int", nullable: false),
                    StatusTransport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraTest_DriverModel_DriverModelId",
                        column: x => x.DriverModelId,
                        principalTable: "DriverModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraTest_LocationModel_LocationModelId",
                        column: x => x.LocationModelId,
                        principalTable: "LocationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraTest_DriverModelId",
                table: "TraTest",
                column: "DriverModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TraTest_LocationModelId",
                table: "TraTest",
                column: "LocationModelId");
        }
    }
}
