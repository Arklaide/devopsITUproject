using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MInitweetApi.Migrations
{
    public partial class newkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_Id1",
                table: "Message",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "who_useruser_Id",
                table: "Follower",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "whom_useruser_Id",
                table: "Follower",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follower",
                table: "Follower",
                columns: new[] { "who_id", "whom_id" });

            migrationBuilder.CreateIndex(
                name: "IX_Message_author_id",
                table: "Message",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_user_Id1",
                table: "Message",
                column: "user_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Follower_who_useruser_Id",
                table: "Follower",
                column: "who_useruser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Follower_whom_useruser_Id",
                table: "Follower",
                column: "whom_useruser_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_User_who_useruser_Id",
                table: "Follower",
                column: "who_useruser_Id",
                principalTable: "User",
                principalColumn: "user_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_User_whom_useruser_Id",
                table: "Follower",
                column: "whom_useruser_Id",
                principalTable: "User",
                principalColumn: "user_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_author_id",
                table: "Message",
                column: "author_id",
                principalTable: "User",
                principalColumn: "user_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_user_Id1",
                table: "Message",
                column: "user_Id1",
                principalTable: "User",
                principalColumn: "user_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follower_User_who_useruser_Id",
                table: "Follower");

            migrationBuilder.DropForeignKey(
                name: "FK_Follower_User_whom_useruser_Id",
                table: "Follower");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_author_id",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_user_Id1",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_author_id",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_user_Id1",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follower",
                table: "Follower");

            migrationBuilder.DropIndex(
                name: "IX_Follower_who_useruser_Id",
                table: "Follower");

            migrationBuilder.DropIndex(
                name: "IX_Follower_whom_useruser_Id",
                table: "Follower");

            migrationBuilder.DropColumn(
                name: "user_Id1",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "who_useruser_Id",
                table: "Follower");

            migrationBuilder.DropColumn(
                name: "whom_useruser_Id",
                table: "Follower");
        }
    }
}
