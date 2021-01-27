using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CivicHub.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "varbinary(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AK_Users_Mail", x => x.Mail);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Issues_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IssueStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueStates_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueStates_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IssueStateComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStateComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueStateComments_IssueStates_IssueStateId",
                        column: x => x.IssueStateId,
                        principalTable: "IssueStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueStateComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IssueStatePhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Photo = table.Column<string>(type: "varbinary(max)", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStatePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueStatePhotos_IssueStates_IssueStateId",
                        column: x => x.IssueStateId,
                        principalTable: "IssueStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueStateReactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proOrContra = table.Column<bool>(type: "bit", nullable: false),
                    dateGiven = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStateReactions", x => x.Id);
                    table.UniqueConstraint("AK_IssueStateReactions_UserId_IssueStateId", x => new { x.UserId, x.IssueStateId });
                    table.ForeignKey(
                        name: "FK_IssueStateReactions_IssueStates_IssueStateId",
                        column: x => x.IssueStateId,
                        principalTable: "IssueStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueStateReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IssueStateVideos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Photo = table.Column<string>(type: "varbinary(max)", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStateVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueStateVideos_IssueStates_IssueStateId",
                        column: x => x.IssueStateId,
                        principalTable: "IssueStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueStateCommentPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueStateCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Photo = table.Column<string>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueStateCommentPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueStateCommentPhotos_IssueStateComments_IssueStateCommentId",
                        column: x => x.IssueStateCommentId,
                        principalTable: "IssueStateComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_UserId",
                table: "Issues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStateCommentPhotos_IssueStateCommentId",
                table: "IssueStateCommentPhotos",
                column: "IssueStateCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStateComments_IssueStateId",
                table: "IssueStateComments",
                column: "IssueStateId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStateComments_UserId",
                table: "IssueStateComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStatePhotos_IssueStateId",
                table: "IssueStatePhotos",
                column: "IssueStateId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStateReactions_IssueStateId",
                table: "IssueStateReactions",
                column: "IssueStateId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStates_IssueId",
                table: "IssueStates",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStates_StateId",
                table: "IssueStates",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStateVideos_IssueStateId",
                table: "IssueStateVideos",
                column: "IssueStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueStateCommentPhotos");

            migrationBuilder.DropTable(
                name: "IssueStatePhotos");

            migrationBuilder.DropTable(
                name: "IssueStateReactions");

            migrationBuilder.DropTable(
                name: "IssueStateVideos");

            migrationBuilder.DropTable(
                name: "IssueStateComments");

            migrationBuilder.DropTable(
                name: "IssueStates");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
