using DelCars.Domain.Models.Car;

namespace DelCars.Application.Interfaces
{
    public interface IRentCarApplicationService
    {
        Task<Car> RentCar(Guid id, DateTime returnDate);
        Task<(bool, string)> ReturnCar(Guid id);
    }
}
