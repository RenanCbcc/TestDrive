using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.models
{
    public class Scheduling
    {
        public Vehicle Vehicle { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public TimeSpan SchedulingTime { get; set; }
        private DateTime _dateTime;

        public Scheduling(Vehicle vehicle)
        {
            Vehicle = vehicle;
            _dateTime = DateTime.Today;
        }

        public DateTime SchedulingDate { get { return _dateTime; } set { _dateTime = value; } }

    }
}
