using Card_Tracker_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card_Tracker_v3.ViewModels
{
    //This ViewModel is supposed to be made to import the repository data as well as the list of cards
    public class CollectionViewerViewModel
    {
        public List<CardRepositories> CardRepositories { get; set; }
        public List<CardRepositoryLookUp> CardRepositoryLookUp { get; set; }
    }
}
