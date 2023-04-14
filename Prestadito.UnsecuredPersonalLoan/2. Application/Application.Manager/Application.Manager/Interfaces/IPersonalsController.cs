using Microsoft.AspNetCore.Http;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.GetPersonalById;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.UpdatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.CreatePersonal;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Interfaces
{
    public interface IPersonalsController
    {
        ValueTask<IResult> CreatePersonal(CreatePersonalRequest request, string path);
        ValueTask<IResult> GetAllPersonals();
        ValueTask<IResult> GetActivePersonals();
        ValueTask<IResult> GetPersonalById(GetPersonalByIdRequest request);
        ValueTask<IResult> UpdatePersonal(UpdatePersonalRequest request);
        ValueTask<IResult> DisablePersonal(string id);
        ValueTask<IResult> DeletePersonal(DeletePersonalRequest request);
    }
}
