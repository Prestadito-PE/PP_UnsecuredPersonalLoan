using MongoDB.Driver;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface
{
    public interface IMongoContext
    {
        IMongoCollection<PersonalEntity> Personals { get; }
    }
}
