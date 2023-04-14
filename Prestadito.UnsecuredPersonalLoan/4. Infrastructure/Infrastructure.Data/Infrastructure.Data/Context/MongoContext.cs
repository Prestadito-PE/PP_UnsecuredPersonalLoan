using MongoDB.Driver;
using Prestadito.UnsecuredPersonalLoan.Domain.MainModule.Entities;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Utilities;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Context
{
    public class MongoContext: IMongoContext
    {
        private readonly IMongoDatabase database;

        public MongoContext(IUnsecuredPersonalLoanDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionURI);
            database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<PersonalEntity> Personals
        {
            get
            {
                return database.GetCollection<PersonalEntity>(CollectionsName.colPersonals);
            }
        }
    }
}
