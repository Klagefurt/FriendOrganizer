using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendOrganizer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration_4_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 8, "hugh@hugh.ru", "Viktor", "Hugh Smith" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
