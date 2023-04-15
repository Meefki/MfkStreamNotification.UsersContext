using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_indexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "twitchuserseq",
                schema: "users");

            migrationBuilder.AlterColumn<string>(
                name: "Credentials_Login",
                schema: "users",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Credentials_Email",
                schema: "users",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "Unique_Email",
                schema: "users",
                table: "users",
                column: "Credentials_Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Unique_Login",
                schema: "users",
                table: "users",
                column: "Credentials_Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Unique_Email",
                schema: "users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "Unique_Login",
                schema: "users",
                table: "users");

            migrationBuilder.CreateSequence(
                name: "twitchuserseq",
                schema: "users",
                incrementBy: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Credentials_Login",
                schema: "users",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Credentials_Email",
                schema: "users",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
