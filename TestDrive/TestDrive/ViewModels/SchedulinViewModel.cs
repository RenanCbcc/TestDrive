using System;
using System.Collections.Generic;
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

        public SchedulinViewModel(Vehicle vehicle)
        {
            Scheduling = new Scheduling(vehicle);
            ScheduleCommand = new Command(() => MessagingCenter.Send<Scheduling>(Scheduling, "Scheduling"));
        }       

    }
}
