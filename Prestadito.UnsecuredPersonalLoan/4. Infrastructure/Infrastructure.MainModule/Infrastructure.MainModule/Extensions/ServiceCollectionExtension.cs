using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Context;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Settings;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.MainModule.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UnsecuredPersonalLoanDBSettings>(configuration.GetSection(nameof(UnsecuredPersonalLoanDBSettings)));
            services.AddSingleton<IUnsecuredPersonalLoanDBSettings>(sp => sp.GetRequiredService<IOptions<UnsecuredPersonalLoanDBSettings>>().Value);
            services.AddSingleton<MongoContext>();

            return services;
        }
    }
}
