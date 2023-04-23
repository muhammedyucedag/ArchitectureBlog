using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchitectureBlog.DataAccess.Migrations
{
    public partial class AddLocationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Projects");
        }
    }
}
