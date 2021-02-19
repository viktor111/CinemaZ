using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaZ.Data.Migrations
{
    public partial class UpdateSeatMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColumnType",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Premiere",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Premiere",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PremiereDate",
                table: "Premiere",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MovieRating",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Movie",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Movie",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Cinema",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Cinema",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cinema",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Article",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnType",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Premiere");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Premiere");

            migrationBuilder.DropColumn(
                name: "PremiereDate",
                table: "Premiere");

            migrationBuilder.DropColumn(
                name: "MovieRating",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cinema");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "Article");
        }
    }
}
