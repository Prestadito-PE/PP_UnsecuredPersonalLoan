using Prestadito.UnsecuredPersonalLoan.Application.Services.Interfaces;
using Prestadito.UnsecuredPersonalLoan.Application.Services.Repositories;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Context;

namespace Prestadito.UnsecuredPersonalLoan.Application.Services.Services
{
    public class DataService : IDataService
    {
        private readonly MongoContext context;

        public DataService(MongoContext _context)
        {
            context = _context;
        }

        public IPersonalRepository Personals
        {
            get
            {
                return new PersonalRepository(context.Database);
            }
        }
    }
}
