using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rideshare.Data.Migrations
{
    public partial class CarPhotoColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Cars");
        }
    }
}
