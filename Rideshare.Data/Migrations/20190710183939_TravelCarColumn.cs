using Microsoft.EntityFrameworkCore.Migrations;

namespace Rideshare.Data.Migrations
{
    public partial class TravelCarColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Travels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Travels_CarId",
                table: "Travels",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Cars_CarId",
                table: "Travels",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Cars_CarId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_CarId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Travels");
        }
    }
}
