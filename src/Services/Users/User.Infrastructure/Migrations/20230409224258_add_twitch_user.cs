using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_twitch_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "twitchuserseq",
                schema: "users",
                incrementBy: 10);

            migrationBuilder.AddColumn<int>(
                name: "TwitchUserId",
                schema: "users",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "twitch_users",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _scopes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_twitch_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_TwitchUserId",
                schema: "users",
                table: "users",
                column: "TwitchUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_twitch_users_TwitchUserId",
                schema: "users",
                table: "users",
                column: "TwitchUserId",
                principalSchema: "users",
                principalTable: "twitch_users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_twitch_users_TwitchUserId",
                schema: "users",
                table: "users");

            migrationBuilder.DropTable(
                name: "twitch_users",
                schema: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_TwitchUserId",
                schema: "users",
                table: "users");

            migrationBuilder.DropColumn(
                name: "TwitchUserId",
                schema: "users",
                table: "users");

            migrationBuilder.DropSequence(
                name: "twitchuserseq",
                schema: "users");
        }
    }
}
