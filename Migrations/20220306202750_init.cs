using Microsoft.EntityFrameworkCore.Migrations;

namespace Card_Tracker_v3.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardRepositories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepositoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardRepositories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardRepositoryLookUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardApiID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardRepositoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardRepositoryLookUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardRepositoryLookUp_CardRepositories_CardRepositoriesId",
                        column: x => x.CardRepositoriesId,
                        principalTable: "CardRepositories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardRepositoryLookUp_CardRepositoriesId",
                table: "CardRepositoryLookUp",
                column: "CardRepositoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardRepositoryLookUp");

            migrationBuilder.DropTable(
                name: "CardRepositories");
        }
    }
}
