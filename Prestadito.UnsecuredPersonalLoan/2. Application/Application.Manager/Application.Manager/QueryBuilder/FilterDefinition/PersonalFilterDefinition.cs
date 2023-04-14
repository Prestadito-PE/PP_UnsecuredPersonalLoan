using MongoDB.Driver;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.QueryBuilder.FilterDefinition
{
    public static class PersonalFilterDefinition
    {
        public static FilterDefinition<PersonalEntity> FindPersonalById(string personalId)
        {
            var filter = Builders<PersonalEntity>.Filter.Eq(s => s.Id, personalId);
            return filter;
        }

        public static FilterDefinition<PersonalEntity> FindAllPersonals()
        {
            var filter = Builders<PersonalEntity>.Filter.Empty;
            return filter;
        }

        public static FilterDefinition<PersonalEntity> FindPersonalsActive()
        {
            var filter = Builders<PersonalEntity>.Filter.Eq(s => s.BlnActive, true);
            return filter;
        }
    }
}
