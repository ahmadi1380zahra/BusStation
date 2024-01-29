using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStationEF.Migrations
{
    /// <inheritdoc />
    public partial class changerel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_JourneySeats_JourneySeatId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_JourneySeats_JourneyId",
                table: "JourneySeats");

            migrationBuilder.AlterColumn<int>(
                name: "JourneySeatId",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "JourneySeats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JourneySeats_JourneyId",
                table: "JourneySeats",
                column: "JourneyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_JourneySeats_JourneySeatId",
                table: "Seat",
                column: "JourneySeatId",
                principalTable: "JourneySeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_JourneySeats_JourneySeatId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_JourneySeats_JourneyId",
                table: "JourneySeats");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "JourneySeats");

            migrationBuilder.AlterColumn<int>(
                name: "JourneySeatId",
                table: "Seat",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_JourneySeats_JourneyId",
                table: "JourneySeats",
                column: "JourneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_JourneySeats_JourneySeatId",
                table: "Seat",
                column: "JourneySeatId",
                principalTable: "JourneySeats",
                principalColumn: "Id");
        }
    }
}
