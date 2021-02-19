using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaZ.Data.Migrations
{
    public partial class AddNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MovieRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieRoom");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Movie");
        }
    }
}
