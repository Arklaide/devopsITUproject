using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MInitweetApi.Migrations
{
    public partial class newnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "user_Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Message",
                newName: "message_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_Id",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "message_Id",
                table: "Message",
                newName: "Id");
        }
    }
}
