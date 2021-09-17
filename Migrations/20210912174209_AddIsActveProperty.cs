using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreVueStarter.Migrations
{
    public partial class AddIsActveProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Quiz",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Quiz");
        }
    }
}
