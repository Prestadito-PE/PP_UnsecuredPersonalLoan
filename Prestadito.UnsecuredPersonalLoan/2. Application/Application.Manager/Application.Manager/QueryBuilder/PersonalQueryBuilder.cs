using MongoDB.Driver;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.QueryBuilder.FilterDefinition;
using Prestadito.UnsecuredPersonalLoan.Application.Manager.QueryBuilder.UpdateDefinition;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.QueryBuilder
{
    public static class PersonalQueryBuilder
    {
        public static Tuple<FilterDefinition<PersonalEntity>, UpdateDefinition<PersonalEntity>> UpdatePersonalDisable(string personalId)
        {
            var filterDefinition = PersonalFilterDefinition.FindPersonalById(personalId);
            var updateDefinition = PersonalUpdateDefinition.Disable();

            return Tuple.Create(filterDefinition, updateDefinition);
        }

        public static FilterDefinition<PersonalEntity> FindAllPersonals()
        {
            var query = PersonalFilterDefinition.FindAllPersonals();
            return query;
        }

        public static FilterDefinition<PersonalEntity> FindPersonalsActive()
        {
            var query = PersonalFilterDefinition.FindPersonalsActive();
            return query;
        }

        public static FilterDefinition<PersonalEntity> FindPersonalById(string personalId)
        {
            var query = PersonalFilterDefinition.FindPersonalById(personalId);
            return query;
        }

        public static UpdateDefinition<PersonalEntity> UpdatePersonal(PersonalEntity entity)
        {
            var updateDefinition = PersonalUpdateDefinition.UpdatePersonal(entity);
            return updateDefinition;
        }
    }
}
