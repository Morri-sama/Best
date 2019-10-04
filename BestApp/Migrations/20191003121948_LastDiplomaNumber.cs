using Microsoft.EntityFrameworkCore.Migrations;

namespace BestApp.Migrations
{
    public partial class LastDiplomaNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastDiplomaNumber",
                table: "Competitions",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDiplomaNumber",
                table: "Competitions");
        }
    }
}
