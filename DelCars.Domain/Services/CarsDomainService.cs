using DelCars.Domain.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelCars.Domain.Services
{
    public class CarsDomainService
    {
        public CarsDomainService() 
        {

        }

        public async Task<bool> Add(Car carToAdd)
        {
            return true;
        }
    }
}
