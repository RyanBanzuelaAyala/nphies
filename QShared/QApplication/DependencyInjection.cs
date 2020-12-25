using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QApplication.EF;

namespace QApplication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericService<>));

            return services;
        }
    }
}
