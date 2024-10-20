using DelCars.Application.ViewModels;

namespace DelCars.Application.Interfaces
{
    public interface ICarsApplicationService
    {
        Task<(bool, string)> RegisterCar(CarViewModel carViewModel);
    }
}
