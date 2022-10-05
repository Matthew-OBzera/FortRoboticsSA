using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortRoboticsSA.Migrations
{
    public partial class AddFreqSubways : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubwayStationUser",
                columns: table => new
                {
                    FreqSubwayStationsSubwayStationId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubwayStationUser", x => new { x.FreqSubwayStationsSubwayStationId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_SubwayStationUser_Subways_FreqSubwayStationsSubwayStationId",
                        column: x => x.FreqSubwayStationsSubwayStationId,
                        principalTable: "Subways",
                        principalColumn: "SubwayStationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubwayStationUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubwayStationUser_UsersUserId",
                table: "SubwayStationUser",
                column: "UsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubwayStationUser");
        }
    }
}
