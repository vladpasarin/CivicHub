using Microsoft.EntityFrameworkCore.Migrations;

namespace CivicHub.Migrations
{
    public partial class signature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "IssueSignatures");

            migrationBuilder.DropColumn(
                name: "Cnp",
                table: "IssueSignatures");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "IssueSignatures");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "IssueSignatures");

            migrationBuilder.DropColumn(
                name: "NumarBuletin",
                table: "IssueSignatures");

            migrationBuilder.DropColumn(
                name: "SerieBuletin",
                table: "IssueSignatures");

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cnp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumarBuletin",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerieBuletin",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cnp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumarBuletin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SerieBuletin",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "IssueSignatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cnp",
                table: "IssueSignatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "IssueSignatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "IssueSignatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumarBuletin",
                table: "IssueSignatures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerieBuletin",
                table: "IssueSignatures",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
