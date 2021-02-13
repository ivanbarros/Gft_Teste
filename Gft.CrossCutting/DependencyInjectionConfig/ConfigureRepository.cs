using Gft.Data.Repository;
using Gft.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Gft.CrossCutting.DependencyInjectionConfig
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
        }
    }
}
