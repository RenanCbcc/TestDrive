using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulingView : ContentPage
    {
        public SchedulinViewModel ViewModel { get; set; }

        public SchedulingView(Vehicle vehicle)
        {
            InitializeComponent();
            ViewModel = new SchedulinViewModel(vehicle);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Scheduling>(this, "Scheduling", (message) =>
            {
                DisplayAlert("Scheduling", string.Format(
                    @"Vehivle: {0}
                    Name: {1}
                    Phone: {2}
                    E-mail: {3}
                    Scheduling Date: {4}
                    Scheduling Time:{5}",
                    message.Vehicle.Name, 
                    message.Name,
                    message.Telephone,
                    message.Email,
                    message.SchedulingDate.ToString("dd/MM/yyy"),
                    message.SchedulingTime), "OK");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Scheduling>(this, "Scheduling");
        }
    }
}