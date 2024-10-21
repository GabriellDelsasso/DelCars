using Delcars.Infra.Data.Postgre.Repositories;
using DelCars.Domain.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelCars.Domain.Services
{
    public class RentCarDomainService
    {
        private readonly CarRepository _carRepository;

        public RentCarDomainService(CarRepository carRepository) 
        {
            _carRepository = carRepository;
        }

        public async Task<Car> GetOne(Guid id)
        {
            return _carRepository.GetOne(id);
        }

        public async Task<bool> RentCar(Car car)
        {
            var result = _carRepository.RentCar(car);

            return result;
        }
    }
}
