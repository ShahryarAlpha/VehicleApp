using VehicleAPI.Models;

namespace VehicleAPI.Services
{
    public interface IVehicleService
    {
        PagedResult<Vehicle> GetVehiclesPaged(int page, int pageSize);
        (bool Success, string ErrorMessage, Vehicle? Vehicle) AddVehicle(Vehicle vehicle);
    }
}