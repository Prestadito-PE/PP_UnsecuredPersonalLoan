using MongoDB.Driver;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Repositories
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly IMongoContext _context;

        public PersonalRepository(IMongoContext context)
        {
            _context = context;
        }

        public async ValueTask<PersonalEntity> GetSingleAsync(FilterDefinition<PersonalEntity> filterDefinition)
        {
            var result = await _context.Personals.FindAsync(filterDefinition);
            return await result.SingleOrDefaultAsync();
        }

        public async ValueTask<IEnumerable<PersonalEntity>> GetAsync(FilterDefinition<PersonalEntity> filterDefinition)
        {
            var result = await _context.Personals.FindAsync(filterDefinition);
            return result.ToEnumerable();
        }

        public async ValueTask InsertOneAsync(PersonalEntity entity)
        {
            await _context.Personals.InsertOneAsync(entity);
        }

        public async ValueTask<bool> UpdateOneAsync(FilterDefinition<PersonalEntity> filterDefinition, UpdateDefinition<PersonalEntity> updateDefinition)
        {
            var result = await _context.Personals.UpdateOneAsync(filterDefinition, updateDefinition);
            return result.IsAcknowledged && result.ModifiedCount == 1;
        }

        public async ValueTask<bool> DeleteOneAsync(FilterDefinition<PersonalEntity> filterDefinition)
        {
            var result = await _context.Personals.DeleteOneAsync(filterDefinition);
            return result.IsAcknowledged && result.DeletedCount == 1;
        }
    }
}
