using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortApp.Migrations
{
    public partial class Install1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "ShortUrls");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateUrl",
                table: "ShortUrls",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LongUrl",
                table: "ShortUrls",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateUrl",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "LongUrl",
                table: "ShortUrls");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "ShortUrls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "ShortUrls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
