using MongoDB.Driver;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Context
{
    public class MongoContext
    {
        private readonly MongoClient client;
        private readonly IMongoDatabase database;

        public MongoContext(IUnsecuredPersonalLoanDBSettings settings)
        {
            client = new MongoClient(settings.ConnectionURI);
            database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoClient Client
        {
            get
            {
                return client;
            }
        }

        public IMongoDatabase Database
        {
            get
            {
                return database;
            }
        }
    }
}
