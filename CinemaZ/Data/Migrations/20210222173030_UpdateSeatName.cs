using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaZ.Data.Migrations
{
    public partial class UpdateSeatName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Row",
                table: "Seat",
                newName: "RowId");

            migrationBuilder.RenameColumn(
                name: "Column",
                table: "Seat",
                newName: "ColumnId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RowId",
                table: "Seat",
                newName: "Row");

            migrationBuilder.RenameColumn(
                name: "ColumnId",
                table: "Seat",
                newName: "Column");
        }
    }
}
