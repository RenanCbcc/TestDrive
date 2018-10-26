using System;

namespace TestDrive.models
{
    public class Scheduling
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public TimeSpan SchedulingTime { get; set; }
        private DateTime _dateTime;

        public Scheduling(string name, string phone, string email, string modle, decimal price)
        {
            Name = name;
            Telephone = phone;
            Email = email;
            Model = modle;
            Price = price;
            _dateTime = DateTime.Today;
        }


        public DateTime SchedulingDate { get { return _dateTime; } private set { _dateTime = value; } }

    }
}
