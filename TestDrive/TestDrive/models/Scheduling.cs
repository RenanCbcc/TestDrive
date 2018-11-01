using SQLite;
using System;

namespace TestDrive.models
{
    public class Scheduling
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public bool IsItScheduled { get; set; }
        public TimeSpan SchedulingTime { get; set; }
        public DateTime SchedulingDate { get; set; }
        

        public string FormatedDate { get { return SchedulingDate.Add(SchedulingTime).ToString("dd/mm/yyyy HH:mm"); } }

        public Scheduling()
        {
            //Constructor need in SchedulingDAO -> _connection.Table<Scheduling>().ToList()
        }

        public Scheduling(string name, string phone, string email, string modle, decimal price)
        {
            Name = name;
            Telephone = phone;
            Email = email;
            Model = modle;
            Price = price;
            SchedulingDate = DateTime.Today;
        }

        public Scheduling(string name, string phone, string email, string modle, decimal price, DateTime date,TimeSpan  hour)
            :this(name,phone,email,modle,price)
        {
            SchedulingDate = date;
            SchedulingTime = hour;
        }      

    }
}
