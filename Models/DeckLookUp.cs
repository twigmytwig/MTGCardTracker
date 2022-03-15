using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card_Tracker_v3.Models
{
    public class DeckLookUp
    {
        public int Id { get; set; }
        public int CommanderDeckId { get; set; }
        public CommanderDeck CommanderDeck { get; set; }
        public string CardName { get; set; }
        public int CardAmount { get; set; }
        public bool LegalityStatus { get; set; } //If the deck is commander the card should be legal in commander
        public bool isCommander { get; set; }
        public int CardTypeId { get; set; }
        public CardType CardType { get; set; }
    }
}
