using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStationEF.Migrations
{
    /// <inheritdoc />
    public partial class makeotherrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_JourneySeats_JourneySeatId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "JourneySeats");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_JourneySeats_JourneySeatId",
                table: "Seat",
                column: "JourneySeatId",
                principalTable: "JourneySeats",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_JourneySeats_JourneySeatId",
                table: "Seat");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "JourneySeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_JourneySeats_JourneySeatId",
                table: "Seat",
                column: "JourneySeatId",
                principalTable: "JourneySeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
