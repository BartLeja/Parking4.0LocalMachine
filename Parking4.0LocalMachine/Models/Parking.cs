using System.Collections.Generic;

namespace Parking4._0LocalMachine.Models
{
    public class Parking
    {
        public string ParkingName { get; set; }
        public double[] Coordinates { get; set; }
        public List<ParkingSpot> ParkingSpots { get; set; }
    }
}
