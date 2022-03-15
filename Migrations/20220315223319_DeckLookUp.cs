using Microsoft.EntityFrameworkCore.Migrations;

namespace Card_Tracker_v3.Migrations
{
    public partial class DeckLookUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeckLookUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommanderDeckId = table.Column<int>(type: "int", nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardAmount = table.Column<int>(type: "int", nullable: false),
                    LegalityStatus = table.Column<bool>(type: "bit", nullable: false),
                    isCommander = table.Column<bool>(type: "bit", nullable: false),
                    CardTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckLookUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeckLookUp_CardType_CardTypeId",
                        column: x => x.CardTypeId,
                        principalTable: "CardType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckLookUp_CommanderDeck_CommanderDeckId",
                        column: x => x.CommanderDeckId,
                        principalTable: "CommanderDeck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckLookUp_CardTypeId",
                table: "DeckLookUp",
                column: "CardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeckLookUp_CommanderDeckId",
                table: "DeckLookUp",
                column: "CommanderDeckId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckLookUp");
        }
    }
}
