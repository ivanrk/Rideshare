using Microsoft.EntityFrameworkCore.Migrations;

namespace Rideshare.Data.Migrations
{
    public partial class AddMessageIsSentColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSent",
                table: "Messages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSent",
                table: "Messages");
        }
    }
}
