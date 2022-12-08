using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieTime.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Parrafo",
                table: "Novedades",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parrafo",
                table: "Novedades");

        }
    }
}
