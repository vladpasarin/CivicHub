using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CivicHub.Migrations
{
    public partial class FE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prizes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prizes", x => x.Id);
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
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PointsUsed = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DateRegistered = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cnp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerieBuletin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumarBuletin = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "PrizeGivens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrizeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateGiven = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryState = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrizeGivens", x => x.Id);
                    table.UniqueConstraint("AK_PrizeGivens_UserId_PrizeId", x => new { x.UserId, x.PrizeId });
                    table.ForeignKey(
                        name: "FK_PrizeGivens_Prizes_PrizeId",
                        column: x => x.PrizeId,
                        principalTable: "Prizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrizeGivens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Follows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follows", x => x.Id);
                    table.UniqueConstraint("AK_Follows_UserId_IssueId", x => new { x.UserId, x.IssueId });
                    table.ForeignKey(
                        name: "FK_Follows_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follows_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "IssueSignatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Vote = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "IssueStateCommentPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueStateCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "IX_Follows_IssueId",
                table: "Follows",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_UserId",
                table: "Issues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueSignatures_IssueStateId",
                table: "IssueSignatures",
                column: "IssueStateId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueStateCommentLikes_IssueStateCommentId",
                table: "IssueStateCommentLikes",
                column: "IssueStateCommentId");

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
                name: "IX_IssueStateVideos_IssueStateId",
                table: "IssueStateVideos",
                column: "IssueStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PrizeGivens_PrizeId",
                table: "PrizeGivens",
                column: "PrizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follows");

            migrationBuilder.DropTable(
                name: "IssueSignatures");

            migrationBuilder.DropTable(
                name: "IssueStateCommentLikes");

            migrationBuilder.DropTable(
                name: "IssueStateCommentPhotos");

            migrationBuilder.DropTable(
                name: "IssueStatePhotos");

            migrationBuilder.DropTable(
                name: "IssueStateReactions");

            migrationBuilder.DropTable(
                name: "IssueStateVideos");

            migrationBuilder.DropTable(
                name: "PrizeGivens");

            migrationBuilder.DropTable(
                name: "IssueStateComments");

            migrationBuilder.DropTable(
                name: "Prizes");

            migrationBuilder.DropTable(
                name: "IssueStates");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
