using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card_Tracker_v3.Models
{
    public class CommanderDeck
    {
        public int Id { get; set; }
        public string DeckName { get; set; }
        public int? AmountOfCards { get; set; }
        public int MagicGameFormatsId { get; set; }
        public MagicGameFormats MagicGameFormats { get; set; }
        public bool PlayReadyStatus { get; set; }
        public float? Cost { get; set; }
    }
}
