using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveysManager.DataAccess.Repository;

namespace SurveysManager.DataAccess
{
    public static class DataAccessDI
    {
        // Register DI dependencies
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            string connectionStr = configuration.GetConnectionString("SurveysManagerDatabase");
            services.AddDbContext<DataContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connectionStr);
            });
            services.AddScoped(typeof(DbContext), typeof(DataContext));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void ConfigureMiddleware(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                context.Database.Migrate();
            }
        }
    }
}