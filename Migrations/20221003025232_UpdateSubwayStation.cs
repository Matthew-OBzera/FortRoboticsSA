using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortRoboticsSA.Migrations
{
    public partial class UpdateSubwayStation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Line",
                table: "Subways",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Subways",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Line",
                table: "Subways");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Subways");
        }
    }
}
