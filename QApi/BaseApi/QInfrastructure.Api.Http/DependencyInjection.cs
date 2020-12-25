namespace QInfrastructure.Api.Http
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using QHttp.BaseApiHttp;
    using QHttp.HttpInjector;
    using QInfrastructure.Api.Http.V3.Eligibility;

    /// <summary>
    /// Defines the <see cref="DependencyInjection" />.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// The AddInfrastructureApiHttp.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddInfrastructureApiHttp(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IHttpApi<>), typeof(BaseApiHttp<>));

            services.AddScoped(typeof(IHttpEligibility), typeof(HttpEligibility));

            return services;
        }
    }
}
