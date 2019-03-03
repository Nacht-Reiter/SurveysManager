using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveysManager.BusinessLogic.Interfaces;
using SurveysManager.BusinessLogic.Services;

namespace SurveysManager.BusinessLogic
{
    public static class BusinessLogicDI
    {
        // Register DI dependencies
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<ISurveyService, SurveyService>();
        }

        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {

        }
    }
}