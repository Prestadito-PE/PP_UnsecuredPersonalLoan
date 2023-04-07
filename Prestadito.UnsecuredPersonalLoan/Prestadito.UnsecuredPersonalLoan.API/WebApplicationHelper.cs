using Microsoft.OpenApi.Models;
using Prestadito.UnsecuredPersonalLoan.API.Controller;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Endpoints;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Extensions;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Application.Services.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Application.Services.Services;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Settings;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.MainModule.Extensions;

namespace Prestadito.UnsecuredPersonalLoan.API
{
    public static class WebApplicationHelper
    {
        public static WebApplication CreateWebApplication(this WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();

            var configuration = provider.GetRequiredService<IConfiguration>();

            builder.Services.AddMongoDbContext(configuration);

            builder.Services.AddScoped<IDataService, DataService>();
            builder.Services.AddScoped<IPersonalsController, PersonalsController>();

            builder.Services.AddValidators();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Prestadio.Micro.UnsecuredPersonalLoan.API",
                });
            });

            builder.Services.AddHealthChecks()
                .AddCheck<MongoDBHealthCheck>(nameof(MongoDBHealthCheck));

            return builder.Build();
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseUnsecuredPersonalLoanEndpoints();

            return app;
        }
    }
}
