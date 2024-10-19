using Microsoft.AspNetCore.Mvc;

namespace DelCars.Controllers
{
    [Route("RentCar")]
    public class RentCarController
    {
        
        public RentCarController() 
        {

        }

        /// <summary>
        /// Endpoint responsible for renting cars
        /// </summary>
        [HttpPost("Rent")]
        public async void Rent()
        {

        }

        /// <summary>
        /// Endpoint responsible for returning the car
        /// </summary>
        [HttpPost("Return")]
        public async void Return()
        {

        }
    }
}
