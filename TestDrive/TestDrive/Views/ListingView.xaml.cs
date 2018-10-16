using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListingView : ContentPage
    {
        public ListingViewModel ViewModel { get; set; }
        public ListingView()
        {
            InitializeComponent();
            ViewModel = new ListingViewModel();
            this.BindingContext = ViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Vehicle>(this, "SelectedVehicle", (message) =>
            {
                Navigation.PushAsync(new ItemDetailView(message));
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
