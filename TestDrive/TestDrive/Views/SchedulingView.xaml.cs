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

        private void buttonScheduling_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Scheduling", string.Format(
@"Vehivle: {0}
Name: {1}
Phone: {2}
E-mail: {3}
Scheduling Date: {4}
Scheduling Time:{5}",
ViewModel.Scheduling.Vehicle.Name, ViewModel.Scheduling.Name,
ViewModel.Scheduling.Telephone,
ViewModel.Scheduling.Email,
ViewModel.Scheduling.SchedulingDate.ToString("dd/MM/yyy"),
ViewModel.Scheduling.SchedulingTime), "OK");
        }
    }
}