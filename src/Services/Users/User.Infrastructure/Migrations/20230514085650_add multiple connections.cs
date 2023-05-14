using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Users.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addmultipleconnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "connections",
                schema: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConnectionTo = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Scopes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_connections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_connections_users_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "users",
                        principalTable: "users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_connections_UserId1",
                schema: "users",
                table: "connections",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "connections",
                schema: "users");

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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scopes = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
