using System;
using TestDrive.models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ItemDetail : ContentPage
    {
        public Vehicle Vehicle { get; set; }

        public ItemDetail(Vehicle vehicle)
        {
            InitializeComponent();
            Vehicle = vehicle;
            BindingContext = new ItemDetailModel(vehicle);
        }


        private void buttonNext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SchedulingView(Vehicle));
        }
    }
}