using BookActivity.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookActivity.Application.Configuration
{
    public sealed class ApplicationModuleConfiguration : IModuleConfiguration
    {
        public IServiceCollection ConfigureDI(IServiceCollection services, IConfiguration Configuration)
        {
            var applicationModuleConfigure = new BookActivity.Application.ModuleConfiguration();
            applicationModuleConfigure.ConfigureDI(services, Configuration);

            return services;
        }
    }
}
