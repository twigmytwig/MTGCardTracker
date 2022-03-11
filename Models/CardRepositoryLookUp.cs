using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card_Tracker_v3.Models
{
    public class CardRepositoryLookUp
    {
        public int Id { get; set; }
        public string CardApiID { get; set; }
        public string CardName { get; set; }
        public int Amount { get; set; }
        public int CardRepositoriesId { get; set; }
        public CardRepositories CardRepositories { get; set; }
    }
}
