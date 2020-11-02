using Microsoft.AspNetCore.SignalR.Client;
using Parking4._0LocalMachine.Models;
using System;
using System.Threading.Tasks;

namespace Parking4._0LocalMachine.Clients
{
    public class SignalRClient: ISignalRClient
    {
        private HubConnection _connection;
        private const string _signalRBaseUrl = "https://parking40cloud20201029175031.azurewebsites.net/parking";

        public async Task ConnectToSignalR()
        {
            _connection = new HubConnectionBuilder()
              .WithUrl(_signalRBaseUrl)
              .Build();

            try
            {
                if(_connection.State != HubConnectionState.Connected)
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task ChangeParkingSpotStatus(ParkingSpot parkingSpot) {
            try
            {
                await _connection.InvokeAsync<ParkingSpot>("SendChangeParkingSpotStatus", parkingSpot);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        } 

        public async Task UpsertParkingMessage(Parking parking)
        {
            try
            {
                await _connection.InvokeAsync<Parking>("SendUpsertParking", parking);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
      
    }
}
