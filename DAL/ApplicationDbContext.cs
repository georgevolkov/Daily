using System.Data.Entity;
using Daily.Core.Models;
using Daily.DAL.Contracts;

namespace Daily.DAL
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Daily.Core.Models.Daily> Dailies { get; set; }
    }
}
