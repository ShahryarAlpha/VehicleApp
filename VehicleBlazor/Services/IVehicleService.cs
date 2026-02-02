using VehicleBlazor.Models;

namespace VehicleBlazor.Services
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehiclesAsync();
        Task<PagedResult<Vehicle>> GetVehiclesPagedAsync(int page, int pageSize);
        Task<bool> AddVehicleAsync(Vehicle vehicle);
    }
}