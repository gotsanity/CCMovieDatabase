using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CCMovieDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedNavPropertyToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActingCredits_Characters_CharacterId",
                table: "ActingCredits");

            migrationBuilder.DropIndex(
                name: "IX_ActingCredits_CharacterId",
                table: "ActingCredits");

            migrationBuilder.AddColumn<int>(
                name: "ActingCreditId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 1,
                column: "ActingCreditId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 2,
                column: "ActingCreditId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ActingCreditId",
                table: "Characters",
                column: "ActingCreditId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ActingCredits_ActingCreditId",
                table: "Characters",
                column: "ActingCreditId",
                principalTable: "ActingCredits",
                principalColumn: "ActingCreditId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ActingCredits_ActingCreditId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ActingCreditId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ActingCreditId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_ActingCredits_CharacterId",
                table: "ActingCredits",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActingCredits_Characters_CharacterId",
                table: "ActingCredits",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "CharacterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
