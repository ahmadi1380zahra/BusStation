using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStationEF.Migrations
{
    /// <inheritdoc />
    public partial class updb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneySeats_Buses_BusId",
                table: "JourneySeats");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneySeats_Buses_BusId",
                table: "JourneySeats",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneySeats_Buses_BusId",
                table: "JourneySeats");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneySeats_Buses_BusId",
                table: "JourneySeats",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
