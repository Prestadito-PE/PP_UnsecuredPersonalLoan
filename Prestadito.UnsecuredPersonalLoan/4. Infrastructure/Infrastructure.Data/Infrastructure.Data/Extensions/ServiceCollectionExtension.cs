using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Context;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Repositories;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Settings;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        private static IServiceCollection AddMongoDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UnsecuredPersonalLoanDBSettings>(configuration.GetSection(nameof(UnsecuredPersonalLoanDBSettings)));
            services.AddSingleton<IUnsecuredPersonalLoanDBSettings>(sp => sp.GetRequiredService<IOptions<UnsecuredPersonalLoanDBSettings>>().Value);
            services.AddScoped<IMongoContext, MongoContext>();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonalRepository, PersonalRepository>();

            return services;
        }

        public static IServiceCollection AddDBServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDbContext(configuration);
            services.AddRepositories();

            return services;
        }
    }
}
