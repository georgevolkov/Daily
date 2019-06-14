using Microsoft.EntityFrameworkCore;
using Daily.Data.Entities;
using System;

namespace Daily.Data
{
    public class AppContext : DbContext
    {

        /* DbSets */
        public DbSet<Entities.Daily> Dailies { get; set; }

        public AppContext(DbContextOptions<AppContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Entities.Daily>().Property(x => x.Today).IsRequired();
            builder.Entity<Entities.Daily>().Property(x => x.Yesterday).IsRequired();
            builder.Entity<Entities.Daily>().Property(x => x.Date).IsRequired();
        }
    }
}
