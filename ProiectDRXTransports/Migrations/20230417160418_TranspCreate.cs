using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDRXTransports.Migrations
{
    public partial class TranspCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportationModel");

            migrationBuilder.CreateTable(
                name: "TransportModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTransport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportModel_DriverModel_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DriverModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportModel_LocationModel_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportModel_DriverId",
                table: "TransportModel",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportModel_LocationId",
                table: "TransportModel",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportModel");

            migrationBuilder.CreateTable(
                name: "TransportationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusTransport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportationModel_DriverModel_DriverId",
                        column: x => x.DriverId,
                        principalTable: "DriverModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportationModel_LocationModel_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LocationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportationModel_DriverId",
                table: "TransportationModel",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationModel_LocationId",
                table: "TransportationModel",
                column: "LocationId");
        }
    }
}
