using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MInitweetApi.Migrations
{
    public partial class Addedfollowers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Follower",
                columns: table => new
                {
                    who_id = table.Column<int>(type: "integer", nullable: false),
                    whom_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follower");
        }
    }
}
