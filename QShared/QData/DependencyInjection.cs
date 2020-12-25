using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QData.Data;
using QData.Repository.V3;
using QData.Repository.V3.Interface;
using EFCore.DbContextFactory.Extensions;

namespace QData
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfigBusiness(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextPool<AppsDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("AppsConnString"),
                     x => x.MigrationsHistoryTable("__AGMigrationHistory", "AGAPI")
                );
            });

            services.AddSqlServerDbContextFactory<AppsDbContext>();
            services.AddScoped<IConfigRepository, ConfigBusiness>();

            return services;
        }
    }
}
