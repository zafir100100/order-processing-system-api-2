using Microsoft.EntityFrameworkCore.Migrations;

namespace ICABAPI.Migrations
{
    public partial class fname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "ICAB",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "ICAB",
                table: "AspNetUsers");
        }
    }
}
