using System;
using TestDrive.models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ItemDetailView : ContentPage
    {
        public Vehicle Vehicle { get; set; }

        public ItemDetailView(Vehicle vehicle)
        {
            InitializeComponent();
            Vehicle = vehicle;
            BindingContext = new ItemDetailModel(vehicle);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Vehicle>(this, "Next", (message) =>
            {
                Navigation.PushAsync(new SchedulingView(message));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Vehicle>(this, "Next");
        }
    }
}