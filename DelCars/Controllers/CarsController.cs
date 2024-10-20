﻿using DelCars.Application.Interfaces;
using DelCars.Application.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DelCars.Controllers
{
    [Route("Cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsApplicationService _carsApplicationService;

        public CarsController(ICarsApplicationService carsApplicationService)
        {
            _carsApplicationService = carsApplicationService;
        }

        /// <summary>
        /// Endpoint responsible for registering new cars
        /// </summary>
        [HttpPost("ResgisterCar")]
        public async Task<ActionResult> RegisterCar([FromBody] CarViewModel carViewModel)
        {
            var result = await _carsApplicationService.RegisterCar(carViewModel);

            if (result.Item1)
                return Ok($"{result.Item2}");

            return BadRequest($"{result.Item2}");
        }

        /// <summary>
        /// Endpoint responsible for searching all cars
        /// </summary>
        [HttpGet("GetCars")]
        public async void GetCars()
        {

        }

        /// <summary>
        /// Endpoint responsible for editing car information
        /// </summary>
        [HttpPost("EditCar")]
        public async void EditCar()
        {

        }

        /// <summary>
        /// Endpoint responsible for deleting car
        /// </summary>
        [HttpDelete("DeleteCar")]
        public async void DeleteCar()
        {

        }
    }
}
