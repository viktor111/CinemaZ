using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaZ.Data.Migrations
{
    public partial class UpdateSeatMovie2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ColumnType",
                table: "Seat",
                newName: "Column");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Column",
                table: "Seat",
                newName: "ColumnType");
        }
    }
}
