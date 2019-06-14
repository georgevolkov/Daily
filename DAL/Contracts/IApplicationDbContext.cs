using System.Data.Entity;
using Daily.Core;
using Daily.Core.Models;

namespace Daily.DAL.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Users> Users { get; set; }
        DbSet<Core.Models.Daily> Dailies { get; set; }
    }
}
