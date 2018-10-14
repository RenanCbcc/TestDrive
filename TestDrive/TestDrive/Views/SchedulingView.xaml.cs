using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulingView : ContentPage
    {
        public Vehicle Vehicle { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public TimeSpan SchedulingTime { get; set; }

        DateTime _dateTime;
        public DateTime SchedulingDate { get { return _dateTime; } set { _dateTime = value; } }


        public SchedulingView(Vehicle vehicle)
        {
            InitializeComponent();
            _dateTime = DateTime.Today;
            Vehicle = vehicle;
            BindingContext = this;
        }

        private void buttonScheduling_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Scheduling", string.Format(
@"Name: {0}
Phone: {1}
E-mail: {2}
Scheduling Date: {3}
Scheduling Time:{4}",
Name, Telephone, Email, SchedulingDate.ToString("dd/MM/yyy"), SchedulingTime), "OK", "Ok");
        }
    }
}