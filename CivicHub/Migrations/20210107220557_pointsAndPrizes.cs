using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CivicHub.Migrations
{
    public partial class pointsAndPrizes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointsUsed",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_PrizeGivens_PrizeId",
                table: "PrizeGivens",
                column: "PrizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrizeGivens");

            migrationBuilder.DropTable(
                name: "Prizes");

            migrationBuilder.DropColumn(
                name: "PointsUsed",
                table: "Users");
        }
    }
}
