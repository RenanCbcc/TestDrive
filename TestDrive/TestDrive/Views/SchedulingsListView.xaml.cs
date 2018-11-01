using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.models;
using TestDrive.Services;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SchedulingsListView : ContentPage
	{
        readonly SchedulingsListViewModel _viewModel;
        public SchedulingsListView ()
		{
			InitializeComponent ();
            _viewModel = new SchedulingsListViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Scheduling>(this, "SaveSelectedScheduling", async (scheduling) => 
            {
                if (!scheduling.IsItScheduled)
                {
                    var response = await DisplayAlert("Resend", "Do you want to resend the scheduling?", "Yes", "No");
                    if (response)
                    {
                        await new SchedulingService().SendScheduling(scheduling);
                        _viewModel.UpdateList();
                    }
                }
            });

            MessagingCenter.Subscribe<Scheduling>(this, "SuccessfulScheduling", async (scheduling) =>
             {
                 await DisplayAlert("Resend", "Resending succesfuly!", "Ok");
             });

            MessagingCenter.Subscribe<Scheduling>(this, "FailedScheduling", async (scheduling) =>
            {
                await DisplayAlert("Resend", "Resending failed!", "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Scheduling>(this, "SaveSelectedScheduling");
            MessagingCenter.Unsubscribe<Scheduling>(this, "FailedScheduling");
            MessagingCenter.Unsubscribe<Scheduling>(this, "SuccessfulScheduling");
        }
    }
}