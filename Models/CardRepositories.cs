using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Card_Tracker_v3.Models
{
    public class CardRepositories
    {
        public int Id { get; set; }
        [Display(Name = "Name of Repository")]
        public string RepositoryName { get; set; }
    }
}
