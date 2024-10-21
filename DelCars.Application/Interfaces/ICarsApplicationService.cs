using DelCars.Application.ViewModels;
using DelCars.Domain.Models.Car;

namespace DelCars.Application.Interfaces
{
    public interface ICarsApplicationService
    {
        Task<(bool, string)> RegisterCar(CarViewModel carViewModel);
        Task<IList<Car>> GetAllCars();
        Task<IList<Car>> GetRentedCars();
        Task<bool> UpdateCarInfo(Guid id, CarViewModel carViewModel);
        Task<bool> DeleteCar(Guid id);
    }
}
