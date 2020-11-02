using Parking4._0LocalMachine.Clients;
using Parking4._0LocalMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Parking4._0LocalMachine.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private Parking _parking;
        private string _baseUrl = "https://localhost:5003/parking/api/";
        private readonly ISignalRClient _signalRClient;

        public ParkingService(IHttpClientFactory httpClientFactory, ISignalRClient signalRClient)
        {
            _parking = new Parking();
            //TODO Remove after tests
            _parking.Coordinates = new double[2] { 19.959764, 50.057488 };
            _parking.ParkingName = "proko";
            _parking.ParkingSpots = new List<ParkingSpot>();
            _httpClientFactory = httpClientFactory;
            _signalRClient = signalRClient;
            _signalRClient.ConnectToSignalR();
        }

        public async Task ParkingSpotStatusChange(ParkingSpot parkingSpot)
        {
            if (_parking.ParkingSpots.Any(ps => ps.Id == parkingSpot.Id))
            {
                await _signalRClient.ChangeParkingSpotStatus(parkingSpot);
            }
            else
            {
                _parking.ParkingSpots.Add(parkingSpot);
                await _signalRClient.UpsertParkingMessage(_parking);
            } 
        }

        public Parking GetParking() => _parking;

        public void ConfigureParking(string parkingName, double[] Coordinates)
        {
            _parking.Coordinates = Coordinates;
            _parking.ParkingName = parkingName;
        }
    }
}
