namespace Prestadito.UnsecuredPersonalLoan.API.Endpoints
{
    public static class EndPoints
    {
        readonly static string basePath = "/api";
        public static WebApplication UseUnsecuredPersonalLoanEndpoints(this WebApplication app)
        {
            app.UsePersonalEndpoints(basePath);

            return app;
        }
    }
}
