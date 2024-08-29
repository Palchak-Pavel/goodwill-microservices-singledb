using GoodwillSingledb.Application.Interfaces;
using GoodwillSingledb.Domain;
using GoodwillSingledb.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace GoodwillSingledb.Persistence
{
    public class GoodwillSingleDbContext : DbContext, IGoodwillSingleDbContext
    {
        public DbSet<Partner> Partners { get; set; }

        public GoodwillSingleDbContext(DbContextOptions<GoodwillSingleDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GoodwillSingledbConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
