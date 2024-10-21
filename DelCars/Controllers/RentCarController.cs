using DelCars.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DelCars.Controllers
{
    [Route("RentCar")]
    public class RentCarController : ControllerBase
    {
        private readonly IRentCarApplicationService _rentCarApplicationService;

        public RentCarController(IRentCarApplicationService rentCarApplicationService) 
        {
            _rentCarApplicationService = rentCarApplicationService;
        }

        /// <summary>
        /// Endpoint responsible for renting cars
        /// </summary>
        [HttpPost("Rent")]
        public async Task<ActionResult> Rent(Guid id, DateTime returnDate)
        {
            var car = await _rentCarApplicationService.RentCar(id, returnDate);

            return Ok(car);
        }

        /// <summary>
        /// Endpoint responsible for returning the car
        /// </summary>
        [HttpPost("Return")]
        public async Task<ActionResult> Return(Guid id)
        {
            var returnCar = await _rentCarApplicationService.ReturnCar(id);

            return Ok(returnCar.Item2);
        }
    }
}
