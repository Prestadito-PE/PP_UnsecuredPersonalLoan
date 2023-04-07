namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Interface
{
    public interface IUnsecuredPersonalLoanDBSettings
    {
        string ConnectionURI { get; set; }
        string DatabaseName { get; set; }
    }
}
