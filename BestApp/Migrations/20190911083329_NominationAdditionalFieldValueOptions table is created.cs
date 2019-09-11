using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestApp.Migrations
{
    public partial class NominationAdditionalFieldValueOptionstableiscreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NominationAdditionalFieldValueOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(nullable: true),
                    NominationAdditionalFieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NominationAdditionalFieldValueOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NominationAdditionalFieldValueOptions_NominationAdditionalFi~",
                        column: x => x.NominationAdditionalFieldId,
                        principalTable: "NominationAdditionalFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NominationAdditionalFieldValueOptions_NominationAdditionalFi~",
                table: "NominationAdditionalFieldValueOptions",
                column: "NominationAdditionalFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NominationAdditionalFieldValueOptions");
        }
    }
}
