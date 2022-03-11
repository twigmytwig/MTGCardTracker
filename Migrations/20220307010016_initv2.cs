using Microsoft.EntityFrameworkCore.Migrations;

namespace Card_Tracker_v3.Migrations
{
    public partial class initv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "CardRepositoryLookUp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CardName",
                table: "CardRepositoryLookUp",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "CardRepositoryLookUp");

            migrationBuilder.DropColumn(
                name: "CardName",
                table: "CardRepositoryLookUp");
        }
    }
}
