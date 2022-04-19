using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zad3.Migrations
{
    public partial class newValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FizzBuzz",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "FizzBuzz",
                type: "varchar(300)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "FizzBuzz");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "FizzBuzz");
        }
    }
}
