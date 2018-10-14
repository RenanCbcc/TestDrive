using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.models
{
    public class Vehicle
    {
        private string _name;
        private decimal _price;
        public const int ABS_BREAK = 400;
        public const int AIR_CONDITIONING = 300;
        public const int MP3_PLAYER = 200;

        public bool HasItAbsBreak { get; set; }
        public bool HasItAirContioning { get; set; }
        public bool HasItMp3Player { get; set; }

        public Vehicle(string name, decimal value)
        {
            this._name = name;
            this._price = value;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string FormatedPrice { get {
                return string.Format("R$ {0} ", _price);
            }
        }

            


    }
}
