using Microsoft.EntityFrameworkCore.Migrations;

namespace UrlShortApp.Migrations
{
    public partial class Uniqui : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortUrls",
                table: "ShortUrls");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShortUrls");

            migrationBuilder.AlterColumn<string>(
                name: "LongUrl",
                table: "ShortUrls",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortUrls",
                table: "ShortUrls",
                column: "ShortURL");

            migrationBuilder.CreateIndex(
                name: "IX_ShortUrls_LongUrl",
                table: "ShortUrls",
                column: "LongUrl",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShortUrls",
                table: "ShortUrls");

            migrationBuilder.DropIndex(
                name: "IX_ShortUrls_LongUrl",
                table: "ShortUrls");

            migrationBuilder.AlterColumn<string>(
                name: "LongUrl",
                table: "ShortUrls",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShortUrls",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShortUrls",
                table: "ShortUrls",
                column: "Id");
        }
    }
}
