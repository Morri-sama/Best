using Microsoft.EntityFrameworkCore.Migrations;

namespace BestApp.Migrations
{
    public partial class xdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "NominationAdditionalFieldValueOptions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NominationId",
                table: "Contests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contests_NominationId",
                table: "Contests",
                column: "NominationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contests_Nominations_NominationId",
                table: "Contests",
                column: "NominationId",
                principalTable: "Nominations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contests_Nominations_NominationId",
                table: "Contests");

            migrationBuilder.DropIndex(
                name: "IX_Contests_NominationId",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "NominationId",
                table: "Contests");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "NominationAdditionalFieldValueOptions",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
