using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.models
{
    public class ListingVehicles
    {
        public List<Vehicle> Vehicles { get; set; }

        public ListingVehicles() {
            Vehicles = new List<Vehicle>
            {
                new Vehicle ("Azera V6",60000),
                new Vehicle ("Fiesta 2.0",50000),
                new Vehicle ("HB20 S",40000)
            };
        }
    }
}
