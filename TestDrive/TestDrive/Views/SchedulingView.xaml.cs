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
            MessagingCenter.Subscribe<Scheduling>(this, "SaveScheduling", async (message) =>
            {
                var response = await DisplayAlert("Save scheduling", "Do you want to send the scheduling?", "Yes", "No");

                if (response)
                {
                    this.ViewModel.SaveScheduling();
                }
            }
            );

            MessagingCenter.Subscribe<Scheduling>(this, "SuccessfulScheduling", async (message) =>
            {
               await DisplayAlert("Scheduling", "Scheduling saved successfuly", "OK");
                //After a succesful scheduling, a want to come back to listing view.
                await Navigation.PopToRootAsync();
            });
            
            MessagingCenter.Subscribe<ArgumentException>(this, "FailScheduling", async (message) =>
            {
                await DisplayAlert("Error", "It was not possible to schedule you test drive. Verify you information and attemp again later", "Ok");
                await Navigation.PopToRootAsync();
            });
            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Scheduling>(this, "SaveScheduling");
            MessagingCenter.Unsubscribe<Scheduling>(this, "SuccessfulScheduling");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FailScheduling");
        }
    }
}