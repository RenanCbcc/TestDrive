using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.models;

namespace TestDrive.ViewModels
{
    public class SchedulinViewModel
    {
        public Scheduling Scheduling { get; set; }

        public SchedulinViewModel(Vehicle vehicle)
        {
            Scheduling = new Scheduling(vehicle);
        }
    }
}
