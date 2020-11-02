using Parking4._0LocalMachine.Models;
using System.Threading.Tasks;

namespace Parking4._0LocalMachine.Services
{
    public interface IParkingService
    {
        Task ParkingSpotStatusChange(ParkingSpot parkingSpot);
        Parking GetParking();
        void ConfigureParking(string parkingName, double[] Coordinates);
    }
}
