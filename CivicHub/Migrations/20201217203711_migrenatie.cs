using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CivicHub.Migrations
{
    public partial class migrenatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "proOrContra",
                table: "IssueStateReactions");

            migrationBuilder.AddColumn<string>(
                name: "Vote",
                table: "IssueStateReactions",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_IssueSignatures_IssueStateId",
                table: "IssueSignatures",
                column: "IssueStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueSignatures");

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
