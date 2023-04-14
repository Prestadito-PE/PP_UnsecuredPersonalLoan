using Microsoft.Extensions.DependencyInjection;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Proxies.Settings.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Proxies.Settings.Proxies;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Proxies.Settings.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddProxies(this IServiceCollection services)
        {
            services.AddHttpClient<ISettingProxy, SettingProxy>();

            return services;
        }
    }
}
