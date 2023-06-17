using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectDRXTransports.Data.Migrations
{
    public partial class ReaddedLocationIdToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AspNetUsers");
        }
    }
}
