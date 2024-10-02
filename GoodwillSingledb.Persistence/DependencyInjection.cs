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
                // TODO: Вопрос №1: зачем ты получаешь строку подключения и кладешь ее в переменную connectionString, а затем эту переменную не используешь?
                // var connectionString = configuration["DbConnection"];
                // services.AddDbContext<GoodwillSingleDbContext>(options =>
                // {
                //     object value = options.UseSqlServer(@"Server=ms-sql2\GoodWill_New;Database=helloappdb;Trusted_Connection=True;");
                // });
                
                var connectionString = configuration["DbConnection"];
                services.AddDbContext<GoodwillSingleDbContext>(options => options.UseSqlServer(connectionString));
                
                //TODO: Здесь вместо метода GetService стоит использовать GetRequireService, т.к. это убережет от nullreferenceexception в рантайме 
                // services.AddScoped<IGoodwillSingleDbContext>(provider =>
                //  provider.GetService<GoodwillSingleDbContext>());
                services.AddScoped<IGoodwillSingleDbContext>(provider => provider.GetRequiredService<GoodwillSingleDbContext>());
                return services;
            }
        }
    }
}
