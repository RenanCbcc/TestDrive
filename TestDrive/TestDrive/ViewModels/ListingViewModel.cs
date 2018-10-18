using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using TestDrive.models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListingViewModel: ViewModelBase
    {
        private const string URL_GET_VEHICLES = "http://aluracar.herokuapp.com";
        private Vehicle _selectedVehicle;
        public ObservableCollection<Vehicle> Vehicles { get; set; }
               
        public Vehicle SelectedVehicle
        {
            get { return _selectedVehicle; }
            set
            {
                _selectedVehicle = value;
                if (_selectedVehicle != null)
                {
                    MessagingCenter.Send<Vehicle>(_selectedVehicle, "SelectedVehicle");
                }
            }
        }

        private bool isItCharging;

        public bool Wait
        {
            get { return isItCharging; }
            set
            {
                isItCharging = value;
                OnPropertyChanged();

            }
        }

        public ListingViewModel()
        {
            Vehicles = new ObservableCollection<Vehicle>();
        }

        public async Task getVehicles()
        {
            Wait = true;
            var result = await new HttpClient().GetStringAsync(URL_GET_VEHICLES);
            var JsonVehicles = JsonConvert.DeserializeObject<JsonVeiculo[]>(result);
            Wait = false;
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
