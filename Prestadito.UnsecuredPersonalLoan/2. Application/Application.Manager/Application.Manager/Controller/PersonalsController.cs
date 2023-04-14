using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.CreatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.DisablePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.GetPersonalById;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.GetPersonalsActive;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.UpdatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.QueryBuilder;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.Utilities;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Constants;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Controller
{
    public class PersonalsController : IPersonalsController
    {
        private readonly IPersonalRepository _personalRepository;
        private readonly IMapper _mapper;

        public PersonalsController(IPersonalRepository personalRepository, IMapper mapper)
        {
            _personalRepository = personalRepository;
            _mapper = mapper;
        }

        public async ValueTask<IResult> CreatePersonal(CreatePersonalRequest request, string path)
        {
            ResponseModel<CreatePersonalResponse> responseModel;

            var entity = _mapper.Map<PersonalEntity>(request);

            await _personalRepository.InsertOneAsync(entity);
            if (string.IsNullOrEmpty(entity.Id))
            {
                responseModel = ResponseModel<CreatePersonalResponse>.GetResponse(ConstantMessages.Personals.USER_FAILED_TO_CREATE);
                return Results.UnprocessableEntity(responseModel);
            }

            responseModel = ResponseModel<CreatePersonalResponse>.GetResponse(_mapper.Map<CreatePersonalResponse>(entity));
            return Results.Created($"{path}/{responseModel.Item.StrId}", responseModel);
        }

        public async ValueTask<IResult> DisablePersonal(string id)
        {
            ResponseModel<DisablePersonalResponse> responseModel;

            var (filterDefinition, updateDefinition) = PersonalQueryBuilder.UpdatePersonalDisable(id);
            var entity = await _personalRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<DisablePersonalResponse>.GetResponse(ConstantMessages.Personals.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }
            entity.BlnActive = false;

            var isPersonalUpdated = await _personalRepository.UpdateOneAsync(filterDefinition, updateDefinition);
            if (!isPersonalUpdated)
            {
                responseModel = ResponseModel<DisablePersonalResponse>.GetResponse(ConstantMessages.Personals.USER_FAILED_TO_DISABLE);
                return Results.UnprocessableEntity(responseModel);
            }

            var mapperResponse = _mapper.Map<DisablePersonalResponse>(entity);
            responseModel = ResponseModel<DisablePersonalResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetActivePersonals()
        {
            ResponseModel<GetPersonalsActiveResponse> responseModel;

            var filterDefinition = PersonalQueryBuilder.FindPersonalsActive();
            var entities = await _personalRepository.GetAsync(filterDefinition);

            var mapperResponse = _mapper.Map<List<GetPersonalsActiveResponse>>(entities.ToList());
            responseModel = ResponseModel<GetPersonalsActiveResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetAllPersonals()
        {
            ResponseModel<PersonalEntity> responseModel;

            var filterDefinition = PersonalQueryBuilder.FindAllPersonals();
            var entities = await _personalRepository.GetAsync(filterDefinition);

            responseModel = ResponseModel<PersonalEntity>.GetResponse(entities.ToList());
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> GetPersonalById(GetPersonalByIdRequest request)
        {
            ResponseModel<GetPersonalByIdResponse> responseModel;

            var filterDefinition = PersonalQueryBuilder.FindPersonalById(request.StrId);
            var entity = await _personalRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<GetPersonalByIdResponse>.GetResponse(ConstantMessages.Personals.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }

            var mapperResponse = _mapper.Map<GetPersonalByIdResponse>(entity);
            responseModel = ResponseModel<GetPersonalByIdResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }
        public async ValueTask<IResult> UpdatePersonal(UpdatePersonalRequest dto)
        {
            ResponseModel<UpdatePersonalResponse> responseModel;

            var filterDefinition = PersonalQueryBuilder.FindPersonalById(dto.Id);
            var entity = await _personalRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<UpdatePersonalResponse>.GetResponse(ConstantMessages.Personals.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }

            entity.BlnActive = dto.BlnActive;
            entity.DteUpdatedAt = DateTime.Now;
            entity.StrUpdateUser = ConstantAPI.System.SYSTEM_USER;

            var updateDefinition = PersonalQueryBuilder.UpdatePersonal(entity);
            var isPersonalUpdated = await _personalRepository.UpdateOneAsync(filterDefinition, updateDefinition);
            if (!isPersonalUpdated)
            {
                responseModel = ResponseModel<UpdatePersonalResponse>.GetResponse(ConstantMessages.Personals.USER_FAILED_TO_DELETE);
                return Results.UnprocessableEntity(responseModel);
            }

            var mapperResponse = _mapper.Map<UpdatePersonalResponse>(entity);
            responseModel = ResponseModel<UpdatePersonalResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }

        public async ValueTask<IResult> DeletePersonal(DeletePersonalRequest request)
        {
            ResponseModel<DeletePersonalResponse> responseModel;

            var filterDefinition = PersonalQueryBuilder.FindPersonalById(request.StrId);
            var entity = await _personalRepository.GetSingleAsync(filterDefinition);
            if (entity is null)
            {
                responseModel = ResponseModel<DeletePersonalResponse>.GetResponse(ConstantMessages.Personals.USER_NOT_FOUND);
                return Results.NotFound(responseModel);
            }

            var isPersonalUpdated = await _personalRepository.DeleteOneAsync(filterDefinition);
            if (!isPersonalUpdated)
            {
                responseModel = ResponseModel<DeletePersonalResponse>.GetResponse(ConstantMessages.Personals.USER_FAILED_TO_DELETE);
                return Results.UnprocessableEntity(responseModel);
            }

            var mapperResponse = _mapper.Map<DeletePersonalResponse>(entity);
            responseModel = ResponseModel<DeletePersonalResponse>.GetResponse(mapperResponse);
            return Results.Json(responseModel);
        }
    }
}
