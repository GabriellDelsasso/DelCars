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

        public async Task<(bool, string)> ReturnCar(Guid id)
        {
            var car = await _rentCarDomainService.GetOne(id);

            if (car.Rented && car != null)
            {
                var oldDate = car.ReturnDate;

                var returnCar = await _rentCarDomainService.ReturnCar(car);

                if (returnCar && oldDate <= DateTime.Now)
                {
                    return (returnCar, "Carro devolvido com sucesso!");
                }
                else if(returnCar && oldDate > DateTime.Now)
                {
                    return (returnCar, "Carro devolvido com atraso, será cobrada uma taxa!");
                }

                return (false, "Falha ao devolver carro!");
            }
            throw new Exception("Não foi possível realizar a devolução do carro!");
        }
    }
}
