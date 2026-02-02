using VehicleAPI.Models;

namespace VehicleAPI.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private static List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle { Id = 1, Make = "Toyota", Model = "Camry", Year = 2022 },
            new Vehicle { Id = 2, Make = "Honda", Model = "Accord", Year = 2021 },
            new Vehicle { Id = 3, Make = "Ford", Model = "F-150", Year = 2023 },
            new Vehicle { Id = 4, Make = "Tesla", Model = "Model 3", Year = 2023 },
            new Vehicle { Id = 5, Make = "BMW", Model = "X5", Year = 2022 },
            new Vehicle { Id = 6, Make = "Mercedes", Model = "C-Class", Year = 2021 },
            new Vehicle { Id = 7, Make = "Audi", Model = "A4", Year = 2023 },
            new Vehicle { Id = 8, Make = "Nissan", Model = "Altima", Year = 2022 }
        };

        private static int _nextId = 9;
        private static readonly object _lock = new object();


        public PagedResult<Vehicle> GetPaged(int page, int pageSize)
        {
                var totalCount = _vehicles.Count;
                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var items = _vehicles.OrderBy(v => v.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                return new PagedResult<Vehicle>
                {
                    Items = items,
                    Page = page,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };
        }

        public int GetTotalCount()
        {
            return _vehicles.Count;
        }

        public Vehicle Add(Vehicle vehicle)
        {
            vehicle.Id = _nextId++;
            _vehicles.Add(vehicle);
            return vehicle;
        }
    }
}