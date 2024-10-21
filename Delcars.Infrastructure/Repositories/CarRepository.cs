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

        public bool ExistsByPlate(string plate)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
                optionsBuilder.UseNpgsql(_connection.ConnectionString);

                using (var context = new CarContext(optionsBuilder.Options))
                {
                    return context.car.Any(c => c.Plate == plate);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<Car> GetAll()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
            optionsBuilder.UseNpgsql(_connection.ConnectionString);

            using (var context = new CarContext(optionsBuilder.Options))
            {
                return context.car.ToList();
            }
        }

        public bool Update(Car car)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
            optionsBuilder.UseNpgsql(_connection.ConnectionString);

            using (var context = new CarContext(optionsBuilder.Options))
            {
                var carUpdate = context.car.Find(car.Id);

                if (carUpdate == null)
                    return false;

                carUpdate.Mark = string.IsNullOrEmpty(car.Mark) ? carUpdate.Mark : car.Mark;
                carUpdate.Model = string.IsNullOrEmpty(car.Model) ? carUpdate.Model : car.Model;
                carUpdate.Year = string.IsNullOrEmpty(car.Year) ? carUpdate.Year : car.Year;
                carUpdate.Color = string.IsNullOrEmpty(car.Color) ? carUpdate.Color : car.Color;
                carUpdate.Plate = string.IsNullOrEmpty(car.Plate) ? carUpdate.Plate : car.Plate;

                context.SaveChanges();

                return true;
            }
        }

        public bool Delete(Guid id)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
            optionsBuilder.UseNpgsql(_connection.ConnectionString);

            using (var context = new CarContext(optionsBuilder.Options))
            {
                var carDelete = context.car.Find(id);

                if(carDelete == null)
                    return false;

                context.car.Remove(carDelete);

                context.SaveChanges();

                return true;
            }
        }
    }
}
