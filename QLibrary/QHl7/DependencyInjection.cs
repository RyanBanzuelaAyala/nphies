using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace QHl7
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSghQHl7(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISghQHl7PA, SghQHl7PA>();

            services.AddScoped<ISghQHl7, SghQHl7>();

            return services;
        }
    }
}
