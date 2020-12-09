using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CivicHub.Migrations
{
    public partial class issuestatechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueStates_States_StateId",
                table: "IssueStates");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_IssueStates_StateId",
                table: "IssueStates");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "IssueStates");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "IssueStates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "IssueStates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "IssueStates");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "IssueStates");

            migrationBuilder.AddColumn<Guid>(
                name: "StateId",
                table: "IssueStates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueStates_StateId",
                table: "IssueStates",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueStates_States_StateId",
                table: "IssueStates",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");
        }
    }
}
