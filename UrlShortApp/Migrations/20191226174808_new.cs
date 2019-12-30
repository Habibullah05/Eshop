using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortApp.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShortURL",
                table: "ShortUrls",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_ShortURL",
                table: "ShortUrls",
                column: "ShortURL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_ShortURL",
                table: "ShortUrls");

            migrationBuilder.AlterColumn<string>(
                name: "ShortURL",
                table: "ShortUrls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
