using FluentValidation;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.CreatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.DisablePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.GetPersonalById;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.UpdatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Constants;

namespace Prestadito.UnsecuredPersonalLoan.API.Endpoints
{
    public static class PersonalEndpoints
    {
        readonly static string collection = "personals";
        public static WebApplication UsePersonalEndpoints(this WebApplication app, string basePath)
        {
            string path = $"{basePath}/{collection}";

            app.MapPost(path,
                async (IValidator<CreatePersonalRequest> validator, CreatePersonalRequest dto, IPersonalsController controller) =>
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.CreatePersonal(dto, $"~{path}");
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapGet(path + "/all",
                async (IPersonalsController controller, HttpContext httpContext) =>
                {
                    return await controller.GetAllPersonals();
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapGet(path,
                async (IPersonalsController controller) =>
                {
                    return await controller.GetActivePersonals();
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapGet(path + "/{id}",
                async (IValidator<GetPersonalByIdRequest> validator, string id, IPersonalsController controller) =>
                {
                    var request = new GetPersonalByIdRequest { StrId = id };
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.GetPersonalById(request);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapPut(path,
                async (IValidator<UpdatePersonalRequest> validator, UpdatePersonalRequest dto, IPersonalsController controller) =>
                {
                    var validationResult = await validator.ValidateAsync(dto);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.UpdatePersonal(dto);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapPut(path + "/disable/{id}",
                async (IValidator<DisablePersonalRequest> validator, string id, IPersonalsController controller) =>
                {
                    var request = new DisablePersonalRequest { StrId = id };
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.DisablePersonal(id);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            app.MapDelete(path + "/delete/{id}",
                async (IValidator<DeletePersonalRequest> validator, string id, IPersonalsController controller) =>
                {
                    var request = new DeletePersonalRequest { StrId = id };
                    var validationResult = await validator.ValidateAsync(request);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary());
                    }
                    return await controller.DeletePersonal(request);
                }).WithTags(ConstantAPI.Endpoint.Tag.USERS);

            return app;
        }
    }
}
