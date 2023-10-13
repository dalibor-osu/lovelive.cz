using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLiveCZ.Migrations
{
    /// <inheritdoc />
    public partial class RefactorUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "love_live_cz",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "HasCustomAvatar",
                schema: "love_live_cz",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasCustomBanner",
                schema: "love_live_cz",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasCustomAvatar",
                schema: "love_live_cz",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HasCustomBanner",
                schema: "love_live_cz",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                schema: "love_live_cz",
                table: "Users",
                type: "text",
                nullable: true);
        }
    }
}
