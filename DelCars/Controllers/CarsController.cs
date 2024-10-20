using DelCars.Application.Interfaces;
using DelCars.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DelCars.Controllers
{
    [Route("Cars")]
    public class CarsController
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
        public async Task<(bool, string)> RegisterCar([FromBody] CarViewModel carViewModel)
        {
            var result = await _carsApplicationService.RegisterCar(carViewModel);

            return result;
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
