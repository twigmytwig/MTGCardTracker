using Card_Tracker_v3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card_Tracker_v3.Data
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
        {

        }

        public DbSet<CardRepositories> CardRepositories { get; set; }
        public DbSet<CardRepositoryLookUp> CardRepositoryLookUp { get; set; }
    }
}
