using AutoMapper;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.CreatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.DisablePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.GetPersonalById;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.GetPersonalsActive;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.UpdatePersonal;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Constants;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Profiles
{
    public class PersonalProfile : Profile
    {
        public PersonalProfile()
        {
            CreateMap<CreatePersonalRequest, PersonalEntity>()
                .ForMember(dest => dest.BlnActive, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.StrCreateUser, opt => opt.MapFrom(src => ConstantAPI.System.SYSTEM_USER));

            CreateMap<PersonalEntity, CreatePersonalResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<PersonalEntity, GetPersonalByIdResponse>();

            CreateMap<UpdatePersonalRequest, PersonalEntity>();

            CreateMap<PersonalEntity, UpdatePersonalResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<PersonalEntity, DisablePersonalResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<PersonalEntity, DeletePersonalResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));

            CreateMap<PersonalEntity, GetPersonalsActiveResponse>()
                .ForMember(dest => dest.StrId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
