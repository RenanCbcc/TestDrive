using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.models;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListingView : ContentPage
    {
        public List<Vehicle> _vehicles { get; }
        public ListingView()
        {
            InitializeComponent();
            _vehicles = new ListingVehicles().Vehicles;
            this.BindingContext = this;
        }

        private void listviewVehicles_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vehicle = (Vehicle)e.Item;
            //DisplayAlert("TestDrivre",string.Format("'{0}' selected. It cost '{1}'", vehicle.Name,vehicle.FormatedPrice),"Ok");
            Navigation.PushAsync(new ItemDetail(vehicle));
        }
    }
}
