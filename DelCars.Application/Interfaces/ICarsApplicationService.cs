using DelCars.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelCars.Application.Interfaces
{
    public interface ICarsApplicationService
    {
        Task<(bool, string)> RegisterCar(CarViewModel carViewModel);
    }
}
