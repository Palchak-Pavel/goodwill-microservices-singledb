

namespace GoodwillSingledb.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(GoodwillSingleDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
