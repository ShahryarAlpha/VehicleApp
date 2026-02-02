using VehicleAPI.Models;
using VehicleAPI.Repositories;

namespace VehicleAPI.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;
        private const int MinYear = 1900;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public PagedResult<Vehicle> GetVehiclesPaged(int page, int pageSize)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 50) pageSize = 50;

            return _repository.GetPaged(page, pageSize);
        }

        public (bool Success, string ErrorMessage, Vehicle? Vehicle) AddVehicle(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.Make))
            {
                return (false, "Make is required.", null);
            }

            if (string.IsNullOrWhiteSpace(vehicle.Model))
            {
                return (false, "Model is required.", null);
            }

            var maxYear = DateTime.Now.Year + 1;
            if (vehicle.Year < MinYear || vehicle.Year > maxYear)
            {
                return (false, $"Year must be between {MinYear} and {maxYear}.", null);
            }

            var addedVehicle = _repository.Add(vehicle);
            return (true, string.Empty, addedVehicle);
        }
    }
}