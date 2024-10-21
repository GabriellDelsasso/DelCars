using AutoMapper;
using DelCars.Application.Interfaces;
using DelCars.Domain.Models.Car;
using DelCars.Domain.Services;
using System.Globalization;

namespace DelCars.Application.Services
{
    public class RentCarApplicationService : IRentCarApplicationService
    {
        private readonly RentCarDomainService _rentCarDomainService;
        private readonly IMapper _mapper;

        public RentCarApplicationService(RentCarDomainService rentCarDomainService, IMapper mapper)
        {
            _rentCarDomainService = rentCarDomainService;
            _mapper = mapper;
        }

        public async Task<Car> RentCar(Guid id, DateTime returnDate)
        {
            var car = await _rentCarDomainService.GetOne(id);

            if (!car.Rented && car != null)
            { 
                car.Rented = true;
                car.ReturnDate = returnDate;

                var rentCar = await _rentCarDomainService.RentCar(car);

                if(rentCar)
                    return car;

                throw new Exception("Falha ao alugar carro, tente novamente mais tarde!");
            }

            throw new Exception("O carro não está disponível!");
        }
    }
}
