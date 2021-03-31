using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonSuporte.Migrations
{
    public partial class AddingProblemIdentificator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProblemIdentificator",
                table: "Problem",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProblemIdentificator",
                table: "Problem");
        }
    }
}
