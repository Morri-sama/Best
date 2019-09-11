using Microsoft.EntityFrameworkCore.Migrations;

namespace BestApp.Migrations
{
    public partial class newcolumnIsCustomValueAllowed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCustomValueAllowed",
                table: "NominationAdditionalFields",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCustomValueAllowed",
                table: "NominationAdditionalFields");
        }
    }
}
