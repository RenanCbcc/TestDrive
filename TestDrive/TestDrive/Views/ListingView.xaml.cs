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

        public ListingView()
        {
            InitializeComponent();
        }

        private void listviewVehicles_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vehicle = (Vehicle)e.Item;
            Navigation.PushAsync(new ItemDetail(vehicle));
        }
    }
}
