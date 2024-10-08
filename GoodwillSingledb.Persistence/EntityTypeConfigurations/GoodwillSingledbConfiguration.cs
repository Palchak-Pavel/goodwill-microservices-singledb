using GoodwillSingledb.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GoodwillSingledb.Persistence.EntityTypeConfigurations
{
    public class GoodwillSingledbConfiguration : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            //TODO: Я так понимаю, в курсе все таблицы были в схеме dbo, либо другая бд дыла. При использовании mssql server необходимо указывать, какой таблице соответствует сущносить и схему, если она нестандартная. Это есть в текущей версии проекта, иногда туда стоит заглядывать
            builder.ToTable("Partners", "Sales").HasKey(x => x.PartnerID);
            // builder.HasKey(x => x.PartenrID);
        }
    }
}