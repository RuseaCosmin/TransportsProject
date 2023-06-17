using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDRXTransports.Migrations
{
    public partial class test6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TransportationModel_DriverModelId",
                table: "TransportationModel",
                column: "DriverModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationModel_LocationModelId",
                table: "TransportationModel",
                column: "LocationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportationModel_DriverModel_DriverModelId",
                table: "TransportationModel",
                column: "DriverModelId",
                principalTable: "DriverModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportationModel_LocationModel_LocationModelId",
                table: "TransportationModel",
                column: "LocationModelId",
                principalTable: "LocationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportationModel_DriverModel_DriverModelId",
                table: "TransportationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportationModel_LocationModel_LocationModelId",
                table: "TransportationModel");

            migrationBuilder.DropIndex(
                name: "IX_TransportationModel_DriverModelId",
                table: "TransportationModel");

            migrationBuilder.DropIndex(
                name: "IX_TransportationModel_LocationModelId",
                table: "TransportationModel");
        }
    }
}
