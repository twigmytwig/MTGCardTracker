using Card_Tracker_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card_Tracker_v3.ViewModels
{
    public class UploadDeckViewModel
    {
        public List<DeckLookUp> Cards { get; set; }
        public int DeckId { get; set; }
    }
}
