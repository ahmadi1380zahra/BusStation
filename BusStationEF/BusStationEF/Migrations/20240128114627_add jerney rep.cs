using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusStationEF.Migrations
{
    /// <inheritdoc />
    public partial class addjerneyrep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JorneyReport",
                columns: table => new
                {
                    JorneyReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalReserveCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSoldCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCancealReserveCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCancealSoldCount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalReserveCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSoldCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCancealSoldCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCancealReseveCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JorneyReport", x => x.JorneyReportId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JourneySeats_JorneyReportId",
                table: "JourneySeats",
                column: "JorneyReportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JourneySeats_JorneyReport_JorneyReportId",
                table: "JourneySeats",
                column: "JorneyReportId",
                principalTable: "JorneyReport",
                principalColumn: "JorneyReportId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneySeats_JorneyReport_JorneyReportId",
                table: "JourneySeats");

            migrationBuilder.DropTable(
                name: "JorneyReport");

            migrationBuilder.DropIndex(
                name: "IX_JourneySeats_JorneyReportId",
                table: "JourneySeats");
        }
    }
}
