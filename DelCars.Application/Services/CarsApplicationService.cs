﻿using DelCars.Application.Interfaces;
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
                    var result = await _carsDomainService.Add(_mapper.Map<Car>(carViewModel));

                    return (true, "Carro cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    return (false, "Ocorreu um erro ao cadastrar o carro, tente novamente mais tarde!");
                }
            }

            return (false, "Falha ao cadastrar o carro, falta informações");
        }
    }
}
