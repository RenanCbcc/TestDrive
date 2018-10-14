using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.models;

namespace TestDrive.ViewModels
{
    public class ListingViewModel
    {
        public List<Vehicle> Vehicles { get; }

        public ListingViewModel()
        {
            Vehicles = new ListingVehicles().Vehicles;
        }
    }
}
