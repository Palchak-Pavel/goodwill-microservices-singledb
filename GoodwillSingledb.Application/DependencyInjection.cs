using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using GoodwillSingledb.Application.Common.Mappings;


namespace GoodwillSingledb.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
           this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            
            services.AddAutoMapper(typeof(AssemblyMappingProfile));
            return services;
        }
    }
}
