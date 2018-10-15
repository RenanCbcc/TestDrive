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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Vehicle>(this, "SelectedVehicle", (message) =>
            {
                Navigation.PushAsync(new ItemDetail(message));
            }
            );
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Vehicle>(this, "SelectedVehicle");

        }
    }
}
