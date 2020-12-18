using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CivicHub.Migrations
{
    public partial class IssueStateCommentLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "proOrContra",
                table: "IssueStateReactions");

            migrationBuilder.AddColumn<int>(
                name: "Vote",
                table: "IssueStateReactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IssueSignatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cnp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerieBuletin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumarBuletin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueSignatures", x => x.Id);
                    table.UniqueConstraint("AK_IssueSignatures_UserId_IssueStateId", x => new { x.UserId, x.IssueStateId });
                    table.ForeignKey(
                        name: "FK_IssueSignatures_IssueStates_IssueStateId",
                        column: x => x.IssueStateId,
                        principalTable: "IssueStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueSignatures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IssueStateCommentLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueStateCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStateCommentLikes", x => x.Id);
                    table.UniqueConstraint("AK_IssueStateCommentLikes_UserId_IssueStateCommentId", x => new { x.UserId, x.IssueStateCommentId });
                    table.ForeignKey(
                        name: "FK_IssueStateCommentLikes_IssueStateComments_IssueStateCommentId",
                        column: x => x.IssueStateCommentId,
                        principalTable: "IssueStateComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueStateCommentLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueSignatures_IssueStateId",
                table: "IssueSignatures",
                column: "IssueStateId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStateCommentLikes_IssueStateCommentId",
                table: "IssueStateCommentLikes",
                column: "IssueStateCommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueSignatures");

            migrationBuilder.DropTable(
                name: "IssueStateCommentLikes");

            migrationBuilder.DropColumn(
                name: "Vote",
                table: "IssueStateReactions");

            migrationBuilder.AddColumn<bool>(
                name: "proOrContra",
                table: "IssueStateReactions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
