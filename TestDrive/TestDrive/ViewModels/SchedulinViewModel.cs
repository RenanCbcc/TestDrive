using System;
using System.Windows.Input;
using TestDrive.models;
using TestDrive.Models;
using TestDrive.Services;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class SchedulinViewModel : ViewModelBase
    {
        public Scheduling Scheduling { get; set; }
        public ICommand ScheduleCommand { get; set; }
                
        public string Name
        {
            get { return Scheduling.Name; }
            set
            {
                Scheduling.Name = value;
                OnPropertyChanged();
                ((Command)ScheduleCommand).ChangeCanExecute();
            }
        }
        public string Telephone
        {
            get { return Scheduling.Telephone; }
            set
            {
                Scheduling.Telephone = value;
                OnPropertyChanged();
                ((Command)ScheduleCommand).ChangeCanExecute();
            }
        }
        public string Email
        {
            get { return Scheduling.Email; }
            set
            {
                Scheduling.Email = value;
                OnPropertyChanged();
                ((Command)ScheduleCommand).ChangeCanExecute();
            }
        }

        public DateTime SchedulingDate
        {
            get
            {
                return Scheduling.SchedulingDate;
            }
            set
            {
                Scheduling.SchedulingDate = value;
            }
        }

        public TimeSpan SchedulingTime
        {
            get
            {
                return Scheduling.SchedulingTime;
            }
            set
            {
                Scheduling.SchedulingTime = value;
            }
        }

        public SchedulinViewModel(Vehicle vehicle,User user)
        {
            Scheduling = new Scheduling(user.nome, user.telefone, user.email, vehicle.Name, vehicle.Price);
            ScheduleCommand = new Command(
                () => { MessagingCenter.Send<Scheduling>(Scheduling, "SaveScheduling"); },
                () =>
                {
                    return
                   !string.IsNullOrEmpty(Name)
                && !string.IsNullOrEmpty(Telephone)
                && !string.IsNullOrEmpty(Email);
                }

                );
        }

        public async void SaveScheduling()
        {
            await new SchedulingService().SendScheduling(Scheduling);
        }

        
    }

}
