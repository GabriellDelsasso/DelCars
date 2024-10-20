using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Delcars.Infra.Data.Postgre.Repositories;

namespace DelCars.Infra.CrossCutting.IoC
{
    public static class PostgreInjection
    {
        public static IServiceCollection ConfigurePostgre(this IServiceCollection services, IConfiguration configuration)
        {
            var postgreSqlConnectionString = configuration["PostgreConnectionString"];

            if(postgreSqlConnectionString != null)
            {
                services.AddSingleton<NpgsqlConnection>(p => new NpgsqlConnection(postgreSqlConnectionString));

                services.AddScoped<CarRepository>();
            }

            return services;
        }
    }
}
