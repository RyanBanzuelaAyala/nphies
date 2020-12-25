using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QData.Repository.V3;
using QData.Repository.V3.Interface;
using QDomain.Model.Eligibility;
using QInfrastructure.Api.Service.V3.Eligibility.Model;
using QInfrastructure.Api.Service.V3.Eligibility.Query;

namespace QInfrastructure.Api.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataMediatR(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRequestHandler<EligibilityValidateQuery, EligibilityValidateVM>, EligibilityValidateQueryHandler>();

            return services;
        }
    }
}
