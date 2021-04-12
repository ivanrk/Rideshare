using Microsoft.EntityFrameworkCore.Migrations;

namespace Rideshare.Data.Migrations
{
    public partial class AddCarAdditionalInfoColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "Cars");
        }
    }
}
