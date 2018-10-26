using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.models;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListingView : ContentPage
    {
        public ListingViewModel ViewModel { get; set; }
        private readonly User _user;

        public ListingView(User user)
        {
            InitializeComponent();
            _user = user;
            BindingContext = new ListingViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Vehicle>(this, "SelectedVehicle", (vehicle) =>
            {
                Navigation.PushAsync(new ItemDetailView(vehicle, _user));
            }
            );
            await ViewModel.getVehicles();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Vehicle>(this, "SelectedVehicle");

        }
    }
}
