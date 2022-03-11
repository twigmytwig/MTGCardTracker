using Card_Tracker_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card_Tracker_v3.ViewModels
{
    public class AddCardViewModel
    {
        //This is the view model intended to be used when adding a card to a repository
        public List<CardRepositories> CardRepositories { get; set; }
        public CardRepositoryLookUp CardRepositoryLookUp { get; set; }
    }
}
