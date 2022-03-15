using Microsoft.EntityFrameworkCore.Migrations;

namespace Card_Tracker_v3.Migrations
{
    public partial class AddDeckandGameFormats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MagicGameFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormatName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicGameFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommanderDeck",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmountOfCards = table.Column<int>(type: "int", nullable: true),
                    MagicGameFormatsId = table.Column<int>(type: "int", nullable: false),
                    PlayReadyStatus = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommanderDeck", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommanderDeck_MagicGameFormats_MagicGameFormatsId",
                        column: x => x.MagicGameFormatsId,
                        principalTable: "MagicGameFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommanderDeck_MagicGameFormatsId",
                table: "CommanderDeck",
                column: "MagicGameFormatsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommanderDeck");

            migrationBuilder.DropTable(
                name: "MagicGameFormats");
        }
    }
}
