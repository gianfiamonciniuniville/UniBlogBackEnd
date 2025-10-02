using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Post",
                newName: "Slug");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "Post",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "Post",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Published", "PublishedAt", "Slug" },
                values: new object[] { 1, true, null, "a-day-at-the-beach" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Published", "PublishedAt", "Slug" },
                values: new object[] { 2, true, null, "the-city-of-dreams" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AuthorId", "Published", "PublishedAt", "Slug" },
                values: new object[] { 1, true, null, "the-power-of-nature" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AuthorId", "Published", "PublishedAt", "Slug" },
                values: new object[] { 2, true, null, "the-art-of-music" });

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AuthorId", "Published", "PublishedAt", "Slug" },
                values: new object[] { 1, true, null, "the-magic-of-cooking" });

            migrationBuilder.CreateIndex(
                name: "IX_Post_AuthorId",
                table: "Post",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_User_AuthorId",
                table: "Post",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_User_AuthorId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_AuthorId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Published",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "Slug",
                table: "Post",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Publicado");

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Publicado");

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Publicado");

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Publicado");

            migrationBuilder.UpdateData(
                table: "Post",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: "Publicado");
        }
    }
}
