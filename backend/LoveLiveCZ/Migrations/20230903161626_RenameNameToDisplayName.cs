using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLiveCZ.Migrations
{
    /// <inheritdoc />
    public partial class RenameNameToDisplayName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "love_live_cz",
                table: "Users",
                newName: "DisplayName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayName",
                schema: "love_live_cz",
                table: "Users",
                newName: "Name");
        }
    }
}
