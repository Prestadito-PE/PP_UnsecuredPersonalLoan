using Microsoft.AspNetCore.Builder;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Endpoints
{
    public static class EndPoints
    {
        readonly static string basePath = "/api";
        public static WebApplication UseUnsecuredPersonalLoanEndpoints(this WebApplication app)
        {
            app.UseHealthEndpoints();
            app.UsePersonalEndpoints(basePath);
            return app;
        }
    }
}
