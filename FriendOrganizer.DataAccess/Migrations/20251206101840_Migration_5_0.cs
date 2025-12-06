using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FriendOrganizer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Migration_5_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Friends",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Friends",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Friends",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Friends",
                type: "nvarchar(75)",
                maxLength: 75,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(75)",
                oldMaxLength: 75,
                oldNullable: true);
        }
    }
}
