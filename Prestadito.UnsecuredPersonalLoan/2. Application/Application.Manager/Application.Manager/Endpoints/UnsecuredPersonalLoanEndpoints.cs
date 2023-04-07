using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Interfaces;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Endpoints
{
    public static class UnsecuredPersonalLoanEndpoints
    {
        readonly static string collection = "personal";
        public static WebApplication UsePersonalEndpoints(this WebApplication app, string basePath)
        {
            string path = $"{basePath}/{collection}";

            app.MapPost(path,
                async (IValidator<CreatePersonalDTO> validator, CreatePersonalDTO dto, IPersonalsController controller) =>
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.CreatePersonal(dto, $"~/{path}");
                });

            app.MapGet(path + "/all",
                async (IPersonalsController controller) =>
                {
                    return await controller.GetAllPersonals();
                });

            app.MapGet(path,
                async (IPersonalsController controller) =>
                {
                    return await controller.GetActivePersonals();
                });

            app.MapGet(path + "/{id}",
                async (string id, IPersonalsController controller) =>
                {
                    return await controller.GetPersonalById(id);
                });

            app.MapPut(path,
                async (IValidator<UpdatePersonalDTO> validator, UpdatePersonalDTO dto, IPersonalsController controller) =>
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.UpdatePersonal(dto);
                });

            app.MapPut(path + "/disable/{id}",
                async (string id, IPersonalsController controller) =>
                {
                    return await controller.DisablePersonal(id);
                });

            app.MapDelete(path + "/delete/{id}",
                async (string id, IPersonalsController controller) =>
                {
                    return await controller.DeletePersonal(id);
                });

            return app;
        }
    }
}
