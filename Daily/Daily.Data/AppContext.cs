using Microsoft.EntityFrameworkCore;
using Questionnaire.Data.Entities;
using System;

namespace Questionnaire.Data
{
    public class AppContext : DbContext
    {

        /* DbSets */
        public DbSet<Answer> Answers { get; set; }

        public AppContext(DbContextOptions<AppContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Answer>().Property(x => x.Status).IsRequired();
            builder.Entity<Answer>().Property(x => x.Sex).IsRequired();
            builder.Entity<Answer>().Property(x => x.Name).IsRequired();
            builder.Entity<Answer>().Property(x => x.IsLikeProgramming).IsRequired();
            builder.Entity<Answer>().Property(x => x.BirthDate).IsRequired();
            builder.Entity<Answer>().Property(x => x.Age).IsRequired();
        }
    }
}
