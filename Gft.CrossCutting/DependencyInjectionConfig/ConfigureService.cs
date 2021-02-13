using Gft.Domain.Interfaces.Services;
using Gft.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gft.CrossCutting.DependencyInjectionConfig
{
    public static class ConfigureService
    {
        public static void ConfigureDependenciesService(this IServiceCollection services)
        {
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<ILogService, LogService>();
        }
    }
}
