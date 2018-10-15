using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListingViewModel
    {
        public List<Vehicle> Vehicles { get; }

        private Vehicle _vehicle;
        public Vehicle SelectedVehicle
        {
            get { return _vehicle; }
            set
            {
                _vehicle = value;
                if (_vehicle != null)
                {
                    MessagingCenter.Send(_vehicle, "SelectedVehicle");
                }
            }
        }

        public ListingViewModel()
        {
            Vehicles = new ListingVehicles().Vehicles;
        }
    }
}
