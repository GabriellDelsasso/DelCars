using Delcars.Infra.Data.Postgre.Context;
using DelCars.Domain.Models.Car;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Delcars.Infra.Data.Postgre.Repositories
{
    public class CarRepository
    {
        private readonly NpgsqlConnection _connection;

        public CarRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public bool Add(Car car)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
                optionsBuilder.UseNpgsql(_connection.ConnectionString);

                using (var context = new CarContext(optionsBuilder.Options))
                {
                    context.car.Add(car);
                    context.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
