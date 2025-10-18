using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendOrganizer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Second_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 3, "walter@gmail.com", "Misha", "Walter" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
