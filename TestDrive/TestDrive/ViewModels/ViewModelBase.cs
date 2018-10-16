using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestDrive.ViewModels
{
    public abstract class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string target = "")
        {
            //The opperator '?' verify whether the PropertyChanged is null.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(target));
        }

    }
}
