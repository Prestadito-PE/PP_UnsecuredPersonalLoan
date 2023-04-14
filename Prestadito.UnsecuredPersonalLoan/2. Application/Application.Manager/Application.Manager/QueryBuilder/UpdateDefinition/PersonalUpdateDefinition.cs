using MongoDB.Driver;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.QueryBuilder.UpdateDefinition
{
    public static class PersonalUpdateDefinition
    {
        public static UpdateDefinition<PersonalEntity> Disable()
        {
            var update = Builders<PersonalEntity>.Update.Set(u => u.BlnActive, false);
            return update;
        }

        public static UpdateDefinition<PersonalEntity> UpdatePersonal(PersonalEntity entity)
        {
            var update = Builders<PersonalEntity>.Update
                .Set(u => u.BlnActive, entity.BlnActive)
                .Set(u => u.DteUpdatedAt, entity.DteUpdatedAt)
                .Set(u => u.StrUpdateUser, entity.StrUpdateUser);
            return update;
        }
    }
}
