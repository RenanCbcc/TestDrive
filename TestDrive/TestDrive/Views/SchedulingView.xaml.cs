using System;
using TestDrive.models;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulingView : ContentPage
    {
        public SchedulinViewModel ViewModel { get; set; }

        public SchedulingView(Vehicle vehicle,User user)
        {
            InitializeComponent();
            ViewModel = new SchedulinViewModel(vehicle, user);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Scheduling>(this, "Scheduling", async (message) =>
            {
                var confirm = await DisplayAlert("Save scheduling", "Do you want to send the scheduling?", "Yes", "No");

                if (confirm)
                {
                    this.ViewModel.SaveScheduling();
                }
            }
            );

            MessagingCenter.Subscribe<Scheduling>(this, "SuccessfulScheduling", (message) =>
            {
                DisplayAlert("Scheduling", string.Format(
                   @"Vehivle: {0}
                    Name: {1}
                    Phone: {2}
                    E-mail: {3}
                    Scheduling Date: {4}
                    Scheduling Time:{5}",
                   message.Model,
                   message.Name,
                   message.Telephone,
                   message.Email,
                   message.SchedulingDate.ToString("dd/MM/yyy"),
                   message.SchedulingTime), "OK");
            });
            
            MessagingCenter.Subscribe<ArgumentException>(this, "FailScheduling", (message) =>
            {
                DisplayAlert("Error", "It was not possible to schedule you test drive. Verify you information and attemp again later", "Ok");
            });
            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Scheduling>(this, "Scheduling");
            MessagingCenter.Unsubscribe<Scheduling>(this, "SuccessfulScheduling");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FailScheduling");
        }
    }
}