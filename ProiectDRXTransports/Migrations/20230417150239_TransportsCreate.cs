using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDRXTransports.Migrations
{
    public partial class TransportsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTransport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverModelId = table.Column<int>(type: "int", nullable: false),
                    LocationModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportModel_DriverModel_DriverModelId",
                        column: x => x.DriverModelId,
                        principalTable: "DriverModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportModel_LocationModel_LocationModelId",
                        column: x => x.LocationModelId,
                        principalTable: "LocationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportModel_DriverModelId",
                table: "TransportModel",
                column: "DriverModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportModel_LocationModelId",
                table: "TransportModel",
                column: "LocationModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportModel");
        }
    }
}
