using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace SurveysManager.Common
{
    public static class CommonDI
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