using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GoodwillSingledb.Application.Interfaces;


namespace GoodwillSingledb.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            {
                var connectionString = configuration["DbConnection"];
                services.AddDbContext<GoodwillSingleDbContext>(options =>
                {
                    object value = options.UseSqlServer(@"Server=ms-sql2\GoodWill_New;Database=helloappdb;Trusted_Connection=True;");
                });
                services.AddScoped<IGoodwillSingleDbContext>(provider =>
                 provider.GetService<GoodwillSingleDbContext>());
                return services;
            }
        }
    }
}
