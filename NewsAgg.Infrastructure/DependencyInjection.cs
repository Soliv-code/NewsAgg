using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsAgg.Infrastructure.Context;

namespace NewsAgg.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NewsAggDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"),
                x => x.MigrationsAssembly(typeof(NewsAggDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            services.AddScoped<INewsAggDbContext>(prov => prov.GetService<NewsAggDbContext>());
            return services;
        }
    }
}
