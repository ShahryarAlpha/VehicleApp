using VehicleAPI.Models;

namespace VehicleAPI.Repositories
{
    public interface IVehicleRepository
    {
        PagedResult<Vehicle> GetPaged(int page, int pageSize);
        int GetTotalCount();
        Vehicle Add(Vehicle vehicle);
    }
}