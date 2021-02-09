using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gft.CrossCutting.MysqlConfig
{
    public static class MySqlConfigurationDependency
    {
        public static void AddMySqlConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(c =>
            {
                return new MySqlConnection(configuration["mysqlDb:connectionString"]);
            });
            services.AddScoped<IDbConnection>(c =>
            {
                var dbConnection = c.GetService<MySqlConnection>();
                dbConnection.Open();

                return dbConnection;
            });

            services.AddScoped(c =>
            {
                return c.GetService<IDbConnection>().BeginTransaction();
            });
        }
    }
}
