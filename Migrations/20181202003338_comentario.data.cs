using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace easyhotelbackend.Migrations
{
    public partial class comentariodata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "data",
                table: "Comentario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data",
                table: "Comentario");
        }
    }
}
