using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class SchedulinViewModel
    {
        public Scheduling Scheduling { get; set; }
        public ICommand ScheduleCommand { get; set; }
        private const string URL_POST_SCHEDULING = "http://aluracar.herokuapp.com/savaragendamento";
   
        public SchedulinViewModel(Vehicle vehicle)
        {
            Scheduling = new Scheduling(vehicle);
            ScheduleCommand = new Command(() => MessagingCenter.Send<Scheduling>(Scheduling, "Scheduling"));
        }

        internal async void SaveScheduling()
        {
            var content = new StringContent("",Encoding.UTF8,"application/json");
            var response = await new HttpClient().PostAsync(URL_POST_SCHEDULING,content);
            if (response.IsSuccessStatusCode) {
                MessagingCenter.Send<Scheduling>(Scheduling, "Successful Scheduling");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "Fail Scheduling");
            }
        }
    }
}
