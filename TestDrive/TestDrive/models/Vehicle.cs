using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.models
{
    public class Vehicle
    {
        private string name;
        private int price;
        public const int ABS_BREAK = 400;
        public const int AIR_CONDITIONING = 300;
        public const int MP3_PLAYER = 200;

        public bool HasItAbsBreak { get; set; }
        public bool HasItAirContioning { get; set; }
        public bool HasItMp3Player { get; set; }

        public Vehicle(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string FormatedPrice { get {
                return string.Format("R$ {0} ", price);
            }
        }

            


    }
}
