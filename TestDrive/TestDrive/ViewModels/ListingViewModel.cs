using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListingViewModel
    {
        public List<Vehicle> Vehicles { get; set; }

        private Vehicle _selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get { return _selectedVehicle; }
            set
            {
                _selectedVehicle = value;
                if (_selectedVehicle != null)
                {
                    MessagingCenter.Send(_selectedVehicle, "SelectedVehicle");
                }
            }
        }

        public ListingViewModel()
        {
            Vehicles = new ListingVehicles().Vehicles;
        }
    }
}
