using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MInitweetApi.Migrations
{
    public partial class updatedindexing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_User_username",
                table: "User",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_username",
                table: "User");
        }
    }
}
