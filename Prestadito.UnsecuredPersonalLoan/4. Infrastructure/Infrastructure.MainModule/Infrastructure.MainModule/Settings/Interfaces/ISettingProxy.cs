using Prestadito.UnsecuredPersonalLoan.Infrastructure.Proxies.Settings.Models;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Proxies.Settings.Models.Parameters;

namespace Prestadito.UnsecuredPersonalLoan.Infrastructure.Proxies.Settings.Interfaces
{
    public interface ISettingProxy
    {
        ValueTask<ResponseProxyModel<ParameterModel>?> GetParameterByCode(string parameterCode);
    }
}
