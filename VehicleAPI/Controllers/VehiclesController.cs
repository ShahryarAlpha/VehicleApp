using Microsoft.AspNetCore.Mvc;
using VehicleAPI.Models;
using VehicleAPI.Services;

namespace VehicleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<Vehicle>), StatusCodes.Status200OK)]
        public ActionResult<PagedResult<Vehicle>> GetVehicles([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var pagedResult = _vehicleService.GetVehiclesPaged(page, pageSize);
            return Ok(pagedResult);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Vehicle), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Vehicle> AddVehicle([FromBody] Vehicle vehicle)
        {
            var (success, errorMessage, addedVehicle) = _vehicleService.AddVehicle(vehicle);

            if (!success)
            {
                return BadRequest(errorMessage);
            }

            return CreatedAtAction(nameof(GetVehicles), new { id = addedVehicle!.Id }, addedVehicle);
        }
    }
}