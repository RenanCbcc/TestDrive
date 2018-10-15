using TestDrive.models;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ItemDetailModel : INotifyPropertyChanged
    {
        public ICommand NextCommand { get; set; }
        public Vehicle Vehicle { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
 
        public string Text_Abs_Break { get { return string.Format("ABS BREAK - R$ {0}", Vehicle.ABS_BREAK); } }
        public string Text_Air_Conditioning { get { return string.Format("AIR CONDITIONING - R$ {0}", Vehicle.AIR_CONDITIONING); } }
        public string Text_Mp3_Player { get { return string.Format("MP3 PLAYER - R$ {0}", Vehicle.MP3_PLAYER); } }


        public ItemDetailModel(Vehicle vehicle)
        {
            Vehicle = vehicle;
            NextCommand = new Command(() => MessagingCenter.Send<Vehicle>(vehicle, "Next"));
        }

        

        public bool HasVehicleAbsBreak
        {
            get { return Vehicle.HasItAbsBreak; }
            set
            {
                Vehicle.HasItAbsBreak = value;
                //Notify th code behind that the fild total_Value is being modified;
                OnPropertyChanged(nameof(Text_Total_Value));
            }
        }

        public bool HasVehicleAirConditioning
        {
            get { return Vehicle.HasItAirContioning; }
            set
            {
                Vehicle.HasItAirContioning = value;
                //Notify th code behind that the fild total_Value is being modified;
                OnPropertyChanged(nameof(Text_Total_Value));
            }
        }

        public bool HasVehicleMp3Player
        {
            get { return Vehicle.HasItMp3Player; }
            set
            {
                Vehicle.HasItMp3Player = value;
                //Notify th code behind that the fild total_Value is being modified;
                OnPropertyChanged(nameof(Text_Total_Value));
            }
        }

        public string Text_Total_Value
        {
            get
            {
                return string.Format("Total value: R$ {0}", Vehicle.Price
                                            + (Vehicle.HasItAbsBreak ? Vehicle.ABS_BREAK : 0)
                                            + (Vehicle.HasItAirContioning ? Vehicle.AIR_CONDITIONING : 0)
                                            + (Vehicle.HasItMp3Player ? Vehicle.MP3_PLAYER : 0)
                                                                                  );
            }
        }



        public void OnPropertyChanged(string target = "")
        {
            //The opperator '?' verify whether the PropertyChanged is null.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(target));
        }



    }
}
