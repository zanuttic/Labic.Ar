using Microsoft.EntityFrameworkCore.Migrations;

namespace Labic.Ar.Migrations
{
    public partial class LabicAr_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Multijugador",
                table: "Juegos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Multijugador",
                table: "Juegos");
        }
    }
}
