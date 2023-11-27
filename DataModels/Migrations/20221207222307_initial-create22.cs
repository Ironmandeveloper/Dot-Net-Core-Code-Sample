using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModels.Migrations
{
    public partial class initialcreate22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaInfo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlReferer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "MetaInfo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UrlReferer",
                table: "Products");
        }
    }
}
