using DelCars.Domain.Models.Car;
using Microsoft.EntityFrameworkCore;

namespace Delcars.Infra.Data.Postgre.Context
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }

        public DbSet<Car> car { get; set; }
    }
}
