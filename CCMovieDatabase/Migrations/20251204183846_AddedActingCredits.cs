using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CCMovieDatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddedActingCredits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName" },
                values: new object[] { 1, "Mike", "Myers" });

            migrationBuilder.InsertData(
                table: "ActingCredits",
                columns: new[] { "ActingCreditId", "CharacterId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActingCredits",
                keyColumn: "ActingCreditId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActingCredits",
                keyColumn: "ActingCreditId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "PersonId",
                keyValue: 1);
        }
    }
}
