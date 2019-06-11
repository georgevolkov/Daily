using System.Data.Entity;
using Daily.Core;

namespace DAL.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Users> Users { get; set; }
        DbSet<Daily> Dailies { get; set; }
    }
}
