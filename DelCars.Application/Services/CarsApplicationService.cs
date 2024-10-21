using DelCars.Application.Interfaces;
using DelCars.Application.ViewModels;
using DelCars.Domain.Services;
using AutoMapper;
using DelCars.Domain.Models.Car;

namespace DelCars.Application.Services
{
    public class CarsApplicationService : ICarsApplicationService
    {
        private readonly CarsDomainService _carsDomainService;
        private readonly IMapper _mapper;

        public CarsApplicationService(CarsDomainService carsDomainService, IMapper mapper)
        {
            _carsDomainService = carsDomainService;
            _mapper = mapper;
        }

        public async Task<(bool, string)> RegisterCar(CarViewModel carViewModel)
        {
            if(carViewModel != null)
            {
                try
                {
                    var carExists = await _carsDomainService.VerifyCarExists(carViewModel.Plate);

                    if (!carExists)
                    {
                        var result = await _carsDomainService.Add(_mapper.Map<Car>(carViewModel));

                        return result;
                    }
                    return (false, "A placa do carro já está cadastrada no sistema!");
                }
                catch (Exception ex)
                {
                    return (false, "Ocorreu um erro ao cadastrar o carro, tente novamente mais tarde!");
                }
            }

            return (false, "Falha ao cadastrar o carro, falta informações");
        }

        public async Task<IList<Car>> GetAllCars()
        {
            var allCars = await _carsDomainService.GetAllCars();

            return allCars;
        }

        public async Task<bool> UpdateCarInfo(Guid id, CarViewModel carViewModel)
        {
            if (carViewModel != null)
            {
                var car = _mapper.Map<Car>(carViewModel);
                car.Id = id;

                var updateCar = await _carsDomainService.UpdateCarInfo(car);

                return updateCar;
            }

            return false;
        }
    }
}
