using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parking4._0LocalMachine.Models;
using Parking4._0LocalMachine.Services;

namespace Parking4._0LocalMachine.Controllers
{
    [ApiController]
    [Route("api/parking")]
    public class ParkingController : ControllerBase
    {

        private readonly ILogger<ParkingController> _logger;
        private readonly IParkingService _parkingService;

        public ParkingController(ILogger<ParkingController> logger,
            IParkingService parkingService)
        {
            _logger = logger;
            _parkingService = parkingService;
        }

        [HttpPost]
        public async Task ParkingSpotStatusChange([FromBody] ParkingSpot parkingSpaceStatus)
            => await _parkingService.ParkingSpotStatusChange(parkingSpaceStatus);

        [HttpPost]
        [Route("configure")]
        public void ConfigureParking(ParkingConfigurationDto parkingConfigurationDto)
        => _parkingService.ConfigureParking(parkingConfigurationDto.ParkingName, parkingConfigurationDto.ParkingCoordinates);

        [HttpGet]
        public Parking GetParking()
            =>  _parkingService.GetParking();
    }
}
