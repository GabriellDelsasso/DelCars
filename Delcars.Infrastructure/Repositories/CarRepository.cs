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

        public Car GetOne(Guid id)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
            optionsBuilder.UseNpgsql(_connection.ConnectionString);

            using (var context = new CarContext(optionsBuilder.Options))
            {
                return context.car.Find(id);
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

        public IList<Car> GetRentedCar()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
            optionsBuilder.UseNpgsql(_connection.ConnectionString);

            using (var context = new CarContext(optionsBuilder.Options))
            {
                return context.car.Where(c => c.Rented).ToList();
            }
        }

        public IList<Car> GetAvaliableCars()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarContext>();
            optionsBuilder.UseNpgsql(_connection.ConnectionString);

            using (var context = new CarContext(optionsBuilder.Options))
            {
                return context.car.Where(c => c.Rented == false).ToList();
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

                foreach(var propertyInfo in typeof(Car).GetProperties())
                {
                    var newValue = propertyInfo.GetValue(car);
                    var oldValue = propertyInfo.GetValue(carUpdate);

                    if(!Equals(newValue, oldValue))
                    {
                        propertyInfo.SetValue(carUpdate, newValue);
                    }
                }

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
