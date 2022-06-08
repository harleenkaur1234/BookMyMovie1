using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookMyMovie.DB.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Duration",
                table: "Movies",
                type: "date",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
