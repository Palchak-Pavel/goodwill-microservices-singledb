using GoodwillSingledb.Domain;
using Microsoft.EntityFrameworkCore;


namespace GoodwillSingledb.Application.Interfaces
{
    public interface IPartenrsDbContext
    {
        DbSet<Partner> Partners { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
