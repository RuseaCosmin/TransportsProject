using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDRXTransports.Migrations
{
    public partial class TrSchCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportationScheduleModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    GateModelId = table.Column<int>(type: "int", nullable: false),
                    TransportationModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationScheduleModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportationScheduleModel_GateModel_GateModelId",
                        column: x => x.GateModelId,
                        principalTable: "GateModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportationScheduleModel_TransportationModel_TransportationModelId",
                        column: x => x.TransportationModelId,
                        principalTable: "TransportationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransportationScheduleModel_GateModelId",
                table: "TransportationScheduleModel",
                column: "GateModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationScheduleModel_TransportationModelId",
                table: "TransportationScheduleModel",
                column: "TransportationModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportationScheduleModel");
        }
    }
}
