using Microsoft.AspNetCore.Http;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Interfaces
{
    public interface IPersonalsController
    {
        ValueTask<IResult> CreatePersonal(CreatePersonalDTO dto, string path);
        ValueTask<IResult> GetAllPersonals();
        ValueTask<IResult> GetActivePersonals();
        ValueTask<IResult> GetPersonalById(string id);
        ValueTask<IResult> UpdatePersonal(UpdatePersonalDTO dto);
        ValueTask<IResult> DisablePersonal(string id);
        ValueTask<IResult> DeletePersonal(string id);
    }
}
