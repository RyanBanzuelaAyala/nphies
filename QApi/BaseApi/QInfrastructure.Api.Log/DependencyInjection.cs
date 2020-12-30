using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace QInfrastructure.Api.Log
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureApiLog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAuditTrail), typeof(AuditTrail));

            return services;
        }
    }
}
