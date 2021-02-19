using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaZ.Data.Migrations
{
    public partial class RemoveMistake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieRoom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MovieRoom",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
