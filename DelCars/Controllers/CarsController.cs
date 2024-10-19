using Microsoft.AspNetCore.Mvc;

namespace DelCars.Controllers
{
    [Route("Cars")]
    public class CarsController
    {

        public CarsController()
        {

        }

        /// <summary>
        /// Endpoint responsible for registering new cars
        /// </summary>
        [HttpPost("ResgisterCar")]
        public async void RegisterCar()
        {

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
