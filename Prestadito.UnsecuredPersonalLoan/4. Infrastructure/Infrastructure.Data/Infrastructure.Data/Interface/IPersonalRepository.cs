using MongoDB.Driver;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface
{
    public interface IPersonalRepository
    {
        ValueTask<PersonalEntity> GetSingleAsync(FilterDefinition<PersonalEntity> filterDefinition);
        ValueTask<IEnumerable<PersonalEntity>> GetAsync(FilterDefinition<PersonalEntity> filterDefinition);
        ValueTask InsertOneAsync(PersonalEntity entity);
        ValueTask<bool> UpdateOneAsync(FilterDefinition<PersonalEntity> filterDefinition, UpdateDefinition<PersonalEntity> updateDefinition);
        ValueTask<bool> DeleteOneAsync(FilterDefinition<PersonalEntity> filterDefinition);
    }
}
