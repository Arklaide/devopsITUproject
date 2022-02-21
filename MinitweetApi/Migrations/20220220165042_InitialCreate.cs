using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinitweetApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    pw_hash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_Id);
                });

            migrationBuilder.CreateTable(
                name: "Follower",
                columns: table => new
                {
                    who_id = table.Column<Guid>(type: "uuid", nullable: false),
                    who_useruser_Id = table.Column<int>(type: "integer", nullable: false),
                    whom_useruser_Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follower", x => x.who_id);
                    table.ForeignKey(
                        name: "FK_Follower_User_who_useruser_Id",
                        column: x => x.who_useruser_Id,
                        principalTable: "User",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follower_User_whom_useruser_Id",
                        column: x => x.whom_useruser_Id,
                        principalTable: "User",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    message_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    pub_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    flagged = table.Column<bool>(type: "boolean", nullable: false),
                    user_Id = table.Column<int>(type: "integer", nullable: false),
                    author_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.message_Id);
                    table.ForeignKey(
                        name: "FK_Message_User_user_Id",
                        column: x => x.user_Id,
                        principalTable: "User",
                        principalColumn: "user_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follower_who_useruser_Id",
                table: "Follower",
                column: "who_useruser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Follower_whom_useruser_Id",
                table: "Follower",
                column: "whom_useruser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_user_Id",
                table: "Message",
                column: "user_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follower");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
