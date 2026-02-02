using System.Net.Http.Json;
using VehicleBlazor.Models;

namespace VehicleBlazor.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly HttpClient _httpClient;

        public VehicleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            try
            {
                var vehicles = await _httpClient.GetFromJsonAsync<List<Vehicle>>("api/vehicles/all");
                return vehicles ?? new List<Vehicle>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PagedResult<Vehicle>> GetVehiclesPagedAsync(int page, int pageSize)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<PagedResult<Vehicle>>(
                    $"api/vehicles?page={page}&pageSize={pageSize}");
                return result ?? new PagedResult<Vehicle>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddVehicleAsync(Vehicle vehicle)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/vehicles", vehicle);
                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}