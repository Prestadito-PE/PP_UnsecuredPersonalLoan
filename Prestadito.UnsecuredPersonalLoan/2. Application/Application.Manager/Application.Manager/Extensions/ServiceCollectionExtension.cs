using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Validators;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreatePersonalDTO>, CreatePersonalValidator>();
            services.AddScoped<IValidator<UpdatePersonalDTO>, UpdatePersonalValidator>();

            return services;
        }
    }
}
