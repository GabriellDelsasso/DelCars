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
                var rentCar = await _rentCarDomainService.RentCar(car, returnDate);

                if(rentCar)
                    return car;

                throw new Exception("Falha ao alugar carro, tente novamente mais tarde!");
            }

            throw new Exception("O carro não está disponível!");
        }

        public async Task<(Car, string)> ReturnCar(Guid id)
        {
            var car = await _rentCarDomainService.GetOne(id);

            if (car.Rented && car != null)
            {
                var returnCar = await _rentCarDomainService.ReturnCar(car);

                if (returnCar && car.ReturnDate <= DateTime.Now)
                {
                    return (car, "Carro devolvido com sucesso!");
                }
                else if(returnCar && car.ReturnDate > DateTime.Now)
                {
                    return (car, "Carro devolvido com atraso, será cobrada uma taxa!");
                }

                return (car, "Falha ao devolver carro!");
            }
            throw new Exception("Não foi possível realizar a devolução do carro!");
        }
    }
}
