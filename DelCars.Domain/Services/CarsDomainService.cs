using Delcars.Infra.Data.Postgre.Repositories;
using DelCars.Domain.Models.Car;

namespace DelCars.Domain.Services
{
    public class CarsDomainService
    {
        private readonly CarRepository _carRepository;

        public CarsDomainService(CarRepository carRepository) 
        {
            _carRepository = carRepository;
        }

        public async Task<bool> Add(Car carToAdd)
        {
            var result = _carRepository.Add(carToAdd);

            return result;
        }
    }
}
