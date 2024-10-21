using DelCars.Application.ViewModels;
using DelCars.Domain.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelCars.Application.Interfaces
{
    public interface IRentCarApplicationService
    {
        Task<Car> RentCar(Guid id, DateTime returnDate);
        Task<(bool, string)> ReturnCar(Guid id);
    }
}
