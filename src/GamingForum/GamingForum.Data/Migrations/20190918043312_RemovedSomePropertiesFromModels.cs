using Microsoft.EntityFrameworkCore.Migrations;

namespace GamingForum.Data.Migrations
{
    public partial class RemovedSomePropertiesFromModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCategoryLikes");

            migrationBuilder.DropTable(
                name: "UserPostLikes");

            migrationBuilder.DropTable(
                name: "UserReplyLikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCategoryLikes",
                columns: table => new
                {
                    LikerId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategoryLikes", x => new { x.LikerId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_UserCategoryLikes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCategoryLikes_AspNetUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPostLikes",
                columns: table => new
                {
                    LikerId = table.Column<string>(nullable: false),
                    PostId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPostLikes", x => new { x.LikerId, x.PostId });
                    table.ForeignKey(
                        name: "FK_UserPostLikes_AspNetUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPostLikes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReplyLikes",
                columns: table => new
                {
                    LikerId = table.Column<string>(nullable: false),
                    ReplyId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReplyLikes", x => new { x.LikerId, x.ReplyId });
                    table.ForeignKey(
                        name: "FK_UserReplyLikes_AspNetUsers_LikerId",
                        column: x => x.LikerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReplyLikes_Replies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCategoryLikes_CategoryId",
                table: "UserCategoryLikes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPostLikes_PostId",
                table: "UserPostLikes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReplyLikes_ReplyId",
                table: "UserReplyLikes",
                column: "ReplyId");
        }
    }
}
