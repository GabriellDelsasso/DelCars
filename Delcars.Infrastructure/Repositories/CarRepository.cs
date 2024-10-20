using Dapper;
using Delcars.Infrastructure.Context;
using DelCars.Domain.Models.Car;

namespace Delcars.Infrastructure.Repositories
{
    public class CarRepository
    {
        public bool Add(Car car)
        {
            using var connection = new DbConnection();

            string query = @"INSERT INTO public.car(
	                        mark, model, year, color, rented, ""returnDate"")
	                        VALUES (@mark, @model, @year, @color, @rented, @returnDate);";

            var result = connection.Connection.Execute(sql: query, param: car);

            return result == 1;
        }
    }
}
