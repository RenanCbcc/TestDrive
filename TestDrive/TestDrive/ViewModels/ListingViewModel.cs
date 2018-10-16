using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListingViewModel
    {
        private const string URL_GET_VEHICLES = "http://aluracar.herokuapp.com";
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
            Vehicles = new List<Vehicle>();
        }

        public async Task getVehicles()
        {
            var result = await new HttpClient().GetStringAsync(URL_GET_VEHICLES);
            var JsonVehicles = JsonConvert.DeserializeObject<JsonVeiculo[]>(result);
            foreach (var vehicle in JsonVehicles)
            {
                this.Vehicles.Add(new Vehicle(vehicle.nome, vehicle.preco));
            }
        }

        class JsonVeiculo
        {
            public string nome { get; set; }
            public int preco { get; set; }
        }
    }
}
