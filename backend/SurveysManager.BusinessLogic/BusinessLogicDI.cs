using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace SurveysManager.BusinessLogic
{
    public static class BusinessLogicDI
    {
        // Register DI dependencies
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

        }

        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {

        }
    }
}