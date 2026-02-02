using Microsoft.AspNetCore.Components;
using VehicleBlazor.Models;
using VehicleBlazor.Services;

namespace VehicleBlazor.Pages
{
    public partial class Vehicles
    {
        [Inject]
        private IVehicleService VehicleService { get; set; } = default!;

        private PagedResult<Vehicle>? pagedResult;
        private Vehicle newVehicle = new();
        private string errorMessage = string.Empty;
        private string successMessage = string.Empty;
        private bool isSubmitting = false;
        private int currentPage = 1;
        private int pageSize = 10;

        protected override async Task OnInitializedAsync()
        {
            await LoadVehiclesAsync();
        }

        private async Task LoadVehiclesAsync()
        {
            try
            {
                pagedResult = await VehicleService.GetVehiclesPagedAsync(currentPage, pageSize);
                errorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                errorMessage = $"Error loading vehicles: {ex.Message}";
                pagedResult = new PagedResult<Vehicle>();
            }
        }

        private async Task HandleValidSubmit()
        {
            if (!ValidateVehicle(newVehicle))
            {
                return;
            }

            isSubmitting = true;
            errorMessage = string.Empty;
            successMessage = string.Empty;

            try
            {
                var success = await VehicleService.AddVehicleAsync(newVehicle);

                if (success)
                {
                    successMessage = $"{newVehicle.Make} {newVehicle.Model} added successfully!";
                    newVehicle = new Vehicle();
                    await LoadVehiclesAsync();
                }
                else
                {
                    errorMessage = "Failed to add vehicle. Please try again.";
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Error: {ex.Message}";
            }
            finally
            {
                isSubmitting = false;
            }
        }

        private bool ValidateVehicle(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.Make))
            {
                errorMessage = "Make is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(vehicle.Model))
            {
                errorMessage = "Model is required.";
                return false;
            }

            if (vehicle.Year < 1900 || vehicle.Year > DateTime.Now.Year + 1)
            {
                errorMessage = $"Year must be between 1900 and {DateTime.Now.Year + 1}.";
                return false;
            }

            return true;
        }

        private async Task GoToPage(int page)
        {
            currentPage = page;
            await LoadVehiclesAsync();
        }

        private async Task OnPageSizeChanged(int newPageSize)
        {
            pageSize = newPageSize;
            currentPage = 1;
            await LoadVehiclesAsync();
        }
    }
}