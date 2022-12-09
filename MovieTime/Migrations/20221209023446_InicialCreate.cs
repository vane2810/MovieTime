using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieTime.Migrations
{
    public partial class InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Series");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Series",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
