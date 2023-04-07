using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Settings
{
    public class UnsecuredPersonalLoanDBSettings : IUnsecuredPersonalLoanDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
