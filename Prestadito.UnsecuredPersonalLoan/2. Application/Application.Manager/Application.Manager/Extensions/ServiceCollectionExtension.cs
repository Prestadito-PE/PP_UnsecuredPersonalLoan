using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.CreatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.DisablePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.GetPersonalById;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.UpdatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Controller;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Validators;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetPersonalByIdRequest>, GetPersonalByIdValidator>();
            services.AddScoped<IValidator<CreatePersonalRequest>, CreatePersonalValidator>();
            services.AddScoped<IValidator<UpdatePersonalRequest>, UpdatePersonalValidator>();
            services.AddScoped<IValidator<DisablePersonalRequest>, DisablePersonalValidator>();
            services.AddScoped<IValidator<DeletePersonalRequest>, DeletePersonalValidator>();

            return services;
        }

        public static IServiceCollection AddUnsecuredPersonalLoanControllers(this IServiceCollection services)
        {
            services.AddScoped<IPersonalsController, PersonalsController>();
            return services;
        }
    }
}
