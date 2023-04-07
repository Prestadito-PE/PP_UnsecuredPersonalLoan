using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Models;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Utilities;
using Prestadito.UnsecuredPersonalLoan.Application.Services.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;
using System.Linq.Expressions;

namespace Prestadito.UnsecuredPersonalLoan.API.Controller
{
    public class PersonalsController : IPersonalsController
    {
        private readonly IPersonalRepository PersonalRepository;
        public PersonalsController(IDataService dataService)
        {
            PersonalRepository = dataService.Personals;
        }

        public async ValueTask<IResult> CreatePersonal(CreatePersonalDTO dto, string path)
        {
            ResponseModel<PersonalModel> responseModel;

            Expression<Func<PersonalEntity, bool>> filter = f => f.StrLoanNumber == dto.strLoanNumber;
            var PersonalExist = await PersonalRepository.GetAllAsync(filter);
            if (PersonalExist is not null && PersonalExist.Count > 0)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse($"Loan number is already exist");
                return Results.NotFound(responseModel);
            }

            /*var rol = Mocks.GetRolByCode(dto.StrRolCode);
            if (rol is null)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Rol not exist");
                return Results.NotFound(responseModel);
            }

            var PersonalStatus = Mocks.GetPersonalStatus("0");
            if (PersonalStatus is null)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("PersonalStatus not exist");
                return Results.NotFound(responseModel);
            }*/

            var entity = new PersonalEntity
            {
                StrLoanNumber = dto.strLoanNumber,
                DteLoanStart = dto.dteLoanStart,
                IntMonths = dto.intMonths,
                DblApr = dto.dblApr,
                DblEacr = dto.dblEacr,
                DblPrincipal = dto.dblPrincipal,
                DteMaturity = dto.dteMaturity,
                StrDoi = dto.strDoi,
                //ObjStatus = PersonalStatus,
                DteCreatedAt = DateTime.UtcNow,
                BlnActive = true
            };

            var newPersonal = await PersonalRepository.InsertOneAsync(entity);
            if (newPersonal is null)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Entity not created");
                return Results.UnprocessableEntity(responseModel);
            }

            var PersonalModelItem = new PersonalModel
            {
                Id = newPersonal.Id,
                StrDoi = newPersonal.StrDoi,
                //ObjRol = rol,
                BlnActive = newPersonal.BlnActive
            };
            responseModel = ResponseModel<PersonalModel>.GetResponse(PersonalModelItem);
            return Results.Created($"{path}/{responseModel.Item.Id}", responseModel);

        }

        public async ValueTask<IResult> GetAllPersonals()
        {
            ResponseModel<PersonalModel> responseModel;

            Expression<Func<PersonalEntity, bool>> filter = f => true;
            var entities = await PersonalRepository.GetAllAsync(filter);

            var PersonalModelItems = entities.Select(u => new PersonalModel
            {
                Id = u.Id,
                StrDoi = u.StrDoi,
                DblApr = u.DblApr,
                DblEacr = u.DblEacr,
                DblPrincipal = u.DblPrincipal,
                DteLoanStart = u.DteLoanStart,
                DteMaturity = u.DteMaturity,
                IntMonths = u.IntMonths,
                StrLoanNumber = u.StrLoanNumber,
                BlnActive = u.BlnActive
            }).ToList();

            responseModel = ResponseModel<PersonalModel>.GetResponse(PersonalModelItems);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetActivePersonals()
        {
            ResponseModel<PersonalModel> responseModel;

            Expression<Func<PersonalEntity, bool>> filter = f => f.BlnActive;
            var entities = await PersonalRepository.GetAllAsync(filter);

            var PersonalModelItems = entities.Select(u => new PersonalModel
            {
                Id = u.Id,
                StrDoi = u.StrDoi,
                DblApr = u.DblApr,
                DblEacr = u.DblEacr,
                DblPrincipal = u.DblPrincipal,
                DteLoanStart = u.DteLoanStart,
                DteMaturity = u.DteMaturity,
                IntMonths = u.IntMonths,
                StrLoanNumber = u.StrLoanNumber,
                BlnActive = u.BlnActive
            }).ToList();

            responseModel = ResponseModel<PersonalModel>.GetResponse(PersonalModelItems);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetPersonalById(string id)
        {
            ResponseModel<PersonalModel> responseModel;

            if (string.IsNullOrWhiteSpace(id))
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Id is empty");
                return Results.BadRequest(responseModel);
            }

            Expression<Func<PersonalEntity, bool>> filter = f => f.Id == id;
            var entity = await PersonalRepository.GetAsync(filter);
            if (entity is null)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Personal not found");
                return Results.NotFound(responseModel);
            }

            var PersonalModelItem = new PersonalModel
            {
                Id = entity.Id,
                StrDoi= entity.StrDoi,
                DblApr = entity.DblApr,
                DblEacr = entity.DblEacr,
                DblPrincipal = entity.DblPrincipal,
                DteLoanStart = entity.DteLoanStart,
                DteMaturity = entity.DteMaturity,
                IntMonths = entity.IntMonths,
                StrLoanNumber = entity.StrLoanNumber,
                BlnActive = entity.BlnActive
            };

            responseModel = ResponseModel<PersonalModel>.GetResponse(PersonalModelItem);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> UpdatePersonal(UpdatePersonalDTO dto)
        {
            ResponseModel<PersonalModel> responseModel;

            Expression<Func<PersonalEntity, bool>> filter = f => f.Id == dto.Id;
            var entity = await PersonalRepository.GetAsync(filter);
            if (entity is null)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Personal not exist");
                return Results.NotFound(responseModel);
            }

            /*var rol = Mocks.GetRolByCode(dto.StrRolCode);
            if (rol is null)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Rol not exist");
                return Results.NotFound(responseModel);
            }

            var PersonalStatus = Mocks.GetPersonalStatus("0");
            if (PersonalStatus is null)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("PersonalStatus not exist");
                return Results.NotFound(responseModel);
            }*/

            entity.StrDoi = dto.StrDoi;
            //entity.ObjStatus = PersonalStatus;

            var isPersonalUpdated = await PersonalRepository.UpdateOneAsync(entity);

            if (!isPersonalUpdated)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Personal not updated");
                return Results.UnprocessableEntity(responseModel);
            }

            var PersonalModelItem = new PersonalModel
            {
                Id = entity.Id,
                StrDoi = entity.StrDoi,
                BlnActive = entity.BlnActive
            };
            responseModel = ResponseModel<PersonalModel>.GetResponse(PersonalModelItem);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> DisablePersonal(string id)
        {
            ResponseModel<PersonalModel> responseModel;

            Expression<Func<PersonalEntity, bool>> filter = f => f.Id == id;
            var entity = await PersonalRepository.GetAsync(filter);
            if (entity is null)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Personal not exist");
                return Results.NotFound(responseModel);
            }

            entity.BlnActive = false;
            var isPersonalUpdated = await PersonalRepository.UpdateOneAsync(entity);
            if (!isPersonalUpdated)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Personal not deleted");
                return Results.UnprocessableEntity(responseModel);
            }

            var PersonalModelItem = new PersonalModel
            {
                Id = entity.Id,
                StrDoi = entity.StrDoi,
                BlnActive = entity.BlnActive
            };
            responseModel = ResponseModel<PersonalModel>.GetResponse(PersonalModelItem);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> DeletePersonal(string id)
        {
            ResponseModel<PersonalModel> responseModel;

            Expression<Func<PersonalEntity, bool>> filter = f => f.Id == id;
            var entity = await PersonalRepository.GetAsync(filter);
            if (entity is null)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Personal not exist");
                return Results.NotFound(responseModel);
            }

            var isPersonalUpdated = await PersonalRepository.DeleteOneAsync(filter);
            if (!isPersonalUpdated)
            {
                responseModel = ResponseModel<PersonalModel>.GetResponse("Personal not deleted");
                return Results.UnprocessableEntity(responseModel);
            }

            var PersonalModelItem = new PersonalModel
            {
                Id = entity.Id,
                StrDoi = entity.StrDoi,
                BlnActive = entity.BlnActive
            };
            responseModel = ResponseModel<PersonalModel>.GetResponse(PersonalModelItem);
            return Results.Json(responseModel);
        }
    }
}
