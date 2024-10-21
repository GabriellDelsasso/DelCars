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

        public async Task<(bool, string)> Add(Car carToAdd)
        {
            var result = _carRepository.Add(carToAdd);

            if(result)
                return (result, "Carro cadastrado com sucesso!");

            return (result, "Falha ao cadastrar o carro!");
        }

        public async Task<bool> VerifyCarExists(string plate)
        {
            var carExists = _carRepository.ExistsByPlate(plate);

            return carExists;
        }

        public async Task<IList<Car>> GetAllCars()
        {
            var allCars = _carRepository.GetAll();

            return allCars;
        }

        public async Task<IList<Car>> GetRentedCar()
        {
            var carsRented = _carRepository.GetRentedCar();

            return carsRented;
        }

        public async Task<IList<Car>> GetAvaliableCars()
        {
            var carsAvaliable = _carRepository.GetAvaliableCars();

            return carsAvaliable;
        }

        public async Task<bool> UpdateCarInfo(Car carToUpdate)
        {
            var updateCar = _carRepository.Update(carToUpdate);

            return updateCar;
        }

        public async Task<bool> DeleteCar(Guid id)
        {
            var updateCar = _carRepository.Delete(id);

            return updateCar;
        }
    }
}
