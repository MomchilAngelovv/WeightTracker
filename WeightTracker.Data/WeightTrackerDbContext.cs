using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeightTracker.Data
{
    public class WeightTrackerDbContext : DbContext
    {
        public WeightTrackerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Weight> Weights { get; set; }
    }
}
