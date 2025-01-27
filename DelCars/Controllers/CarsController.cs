﻿using DelCars.Application.Interfaces;
using DelCars.Application.ViewModels;
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
        [HttpGet("GetAllCars")]
        public async Task<ActionResult> GetAllCars()
        {
            return Ok(await _carsApplicationService.GetAllCars());
        }

        /// <summary>
        /// Endpoint responsible for searching for rental cars
        /// </summary>
        [HttpGet("GetRentedCars")]
        public async Task<ActionResult> GetRentedCars()
        {
            return Ok(await _carsApplicationService.GetRentedCars());
        }

        /// <summary>
        /// Endpoint responsible for searching for available cars
        /// </summary>
        [HttpGet("GetAvailableCars")]
        public async Task<ActionResult> GetAvailableCars()
        {
            return Ok(await _carsApplicationService.GetAvaliableCars());
        }

        /// <summary>
        /// Endpoint responsible for editing car information
        /// </summary>
        [HttpPost("EditCar")]
        public async Task<ActionResult> EditCar(Guid id, [FromBody] CarViewModel carViewModel)
        {
            var result = await _carsApplicationService.UpdateCarInfo(id, carViewModel);

            if (result)
                return Ok();

            return BadRequest("Falha ao Editar informações do carro!");
        }

        /// <summary>
        /// Endpoint responsible for deleting car
        /// </summary>
        [HttpDelete("DeleteCar")]
        public async Task<ActionResult> DeleteCar(Guid id)
        {
            var result = await _carsApplicationService.DeleteCar(id);

            if (result)
                return Ok();

            return BadRequest("Falha ao deletar carro!");
        }
    }
}
