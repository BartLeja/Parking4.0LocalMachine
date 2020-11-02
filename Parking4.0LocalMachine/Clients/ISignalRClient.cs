using Parking4._0LocalMachine.Models;
using System.Threading.Tasks;

namespace Parking4._0LocalMachine.Clients
{
    public interface ISignalRClient
    {
        Task ChangeParkingSpotStatus(ParkingSpot parkingSpot);
        Task UpsertParkingMessage(Parking parking);
        Task ConnectToSignalR();
    }
}
