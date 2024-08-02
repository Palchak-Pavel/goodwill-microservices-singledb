using GoodwillSingledb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GoodwillSingledb.Persistence.EntityTypeConfigurations
{
    public class GoodwillSingledbConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
             builder.HasKey(x => x.PartenrID);
        }
    }
}
