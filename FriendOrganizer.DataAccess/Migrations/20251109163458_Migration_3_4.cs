using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendOrganizer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration_3_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "FirstName" },
                values: new object[] { "simon_trifonov@gmail.com", "Simon" });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[] { 7, "davis@yandex.ru", "Miles", "Davis" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "FirstName" },
                values: new object[] { "trifonov@gmail.com", "Valentin" });
        }
    }
}
