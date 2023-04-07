using MongoDB.Driver;
using Prestadito.UnsecuredPersonalLoan.Application.Services.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Application.Services.Utilities;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;
using System.Linq.Expressions;

namespace Prestadito.UnsecuredPersonalLoan.Application.Services.Repositories
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly IMongoCollection<PersonalEntity> collection;

        public PersonalRepository(IMongoDatabase database)
        {
            collection = database.GetCollection<PersonalEntity>(CollectionsName.Personals);
        }

        public async ValueTask<List<PersonalEntity>> GetAllAsync(Expression<Func<PersonalEntity, bool>> filter)
        {
            var result = await collection.FindAsync(filter);
            return await result.ToListAsync();
        }

        public async ValueTask<PersonalEntity> GetAsync(Expression<Func<PersonalEntity, bool>> filter)
        {
            var result = await collection.FindAsync(filter);
            return await result.SingleOrDefaultAsync();
        }

        public async ValueTask<PersonalEntity> InsertOneAsync(PersonalEntity entity)
        {
            await collection.InsertOneAsync(entity);
            return entity;
        }

        public async ValueTask<bool> UpdateOneAsync(PersonalEntity entity)
        {
            var result = await collection.ReplaceOneAsync(u => u.Id == entity.Id, entity);
            return result.IsAcknowledged;
        }

        public async ValueTask<bool> DeleteOneAsync(Expression<Func<PersonalEntity, bool>> filter)
        {
            var result = await collection.DeleteOneAsync(filter);
            return result.IsAcknowledged;
        }
    }
}
