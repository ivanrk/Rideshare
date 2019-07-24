using Microsoft.EntityFrameworkCore.Migrations;

namespace Rideshare.Data.Migrations
{
    public partial class ApplicantTravelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantTravel",
                columns: table => new
                {
                    ApplicantId = table.Column<string>(nullable: false),
                    TravelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantTravel", x => new { x.ApplicantId, x.TravelId });
                    table.ForeignKey(
                        name: "FK_ApplicantTravel_AspNetUsers_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantTravel_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantTravel_TravelId",
                table: "ApplicantTravel",
                column: "TravelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantTravel");
        }
    }
}
