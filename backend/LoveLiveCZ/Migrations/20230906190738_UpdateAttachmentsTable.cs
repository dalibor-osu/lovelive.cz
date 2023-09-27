using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoveLiveCZ.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAttachmentsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attachments_Path",
                schema: "love_live_cz",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "Path",
                schema: "love_live_cz",
                table: "Attachments",
                newName: "Name");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "love_live_cz",
                table: "Attachments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_UserId",
                schema: "love_live_cz",
                table: "Attachments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Users_UserId",
                schema: "love_live_cz",
                table: "Attachments",
                column: "UserId",
                principalSchema: "love_live_cz",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Users_UserId",
                schema: "love_live_cz",
                table: "Attachments");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_UserId",
                schema: "love_live_cz",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "love_live_cz",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "love_live_cz",
                table: "Attachments",
                newName: "Path");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_Path",
                schema: "love_live_cz",
                table: "Attachments",
                column: "Path",
                unique: true);
        }
    }
}
