using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QApi.V3.Model.Eligibility;
using QApi.V3.Validators.Eligibility;
using TApi.Utilities.Installer;

namespace QApi.Utilities.Installer.AppInstaller
{
    public class ValidatorInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IValidator<NAPHIES_Eligibility_ParamVM>, NAPHIES_Eligibility_ParamValidator>();
        }
    }
}
