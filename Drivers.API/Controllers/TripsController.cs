using Drivers.BL.Services.Trips;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drivers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;

        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }
        [HttpGet("average-trip-duration")]
        public async Task<IActionResult> GetAverageTripDurationForDrivers()
        {
            var result = await _tripsService.GetAverageTripDurationForDriversAsync();
            return Ok(result);
        }

    }
}
