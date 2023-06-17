using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDRXTransports.Migrations
{
    public partial class TransportsCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportModel_DriverModel_DriverModelId",
                table: "TransportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportModel_LocationModel_LocationModelId",
                table: "TransportModel");

            migrationBuilder.DropIndex(
                name: "IX_TransportModel_DriverModelId",
                table: "TransportModel");

            migrationBuilder.DropIndex(
                name: "IX_TransportModel_LocationModelId",
                table: "TransportModel");

            migrationBuilder.DropColumn(
                name: "DriverModelId",
                table: "TransportModel");

            migrationBuilder.DropColumn(
                name: "LocationModelId",
                table: "TransportModel");

            migrationBuilder.CreateIndex(
                name: "IX_TransportModel_DriverId",
                table: "TransportModel",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportModel_LocationId",
                table: "TransportModel",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportModel_DriverModel_DriverId",
                table: "TransportModel",
                column: "DriverId",
                principalTable: "DriverModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportModel_LocationModel_LocationId",
                table: "TransportModel",
                column: "LocationId",
                principalTable: "LocationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransportModel_DriverModel_DriverId",
                table: "TransportModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TransportModel_LocationModel_LocationId",
                table: "TransportModel");

            migrationBuilder.DropIndex(
                name: "IX_TransportModel_DriverId",
                table: "TransportModel");

            migrationBuilder.DropIndex(
                name: "IX_TransportModel_LocationId",
                table: "TransportModel");

            migrationBuilder.AddColumn<int>(
                name: "DriverModelId",
                table: "TransportModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationModelId",
                table: "TransportModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TransportModel_DriverModelId",
                table: "TransportModel",
                column: "DriverModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportModel_LocationModelId",
                table: "TransportModel",
                column: "LocationModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransportModel_DriverModel_DriverModelId",
                table: "TransportModel",
                column: "DriverModelId",
                principalTable: "DriverModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransportModel_LocationModel_LocationModelId",
                table: "TransportModel",
                column: "LocationModelId",
                principalTable: "LocationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
