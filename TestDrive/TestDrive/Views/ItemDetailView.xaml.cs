using System;
using TestDrive.models;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ItemDetailView : ContentPage
    {
        public Vehicle Vehicle { get; private set; }
        public User User { get; private set; }

        public ItemDetailView(Vehicle vehicle,User user)
        {
            InitializeComponent();
            Vehicle = vehicle;
            User = user;
            BindingContext = new ItemDetailModel(vehicle);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Vehicle>(this, "Next", (vehicle) =>
            {
                Navigation.PushAsync(new SchedulingView(vehicle,User));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Vehicle>(this, "Next");
        }
    }
}