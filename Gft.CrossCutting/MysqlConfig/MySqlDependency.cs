using Gft.CrossCutting.DependencyInjectionConfig;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gft.CrossCutting.MysqlConfig
{
    public static class MySqlDependency
    {
        public static void AddMySqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMySqlConfiguration(configuration);
            services.ConfigureDependenciesRepositories();
        }
    }
}
