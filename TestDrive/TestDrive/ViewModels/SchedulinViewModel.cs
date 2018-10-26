using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Interfaces;
using TestDrive.models;
using TestDrive.Models;
using TestDrive.Persistence;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class SchedulinViewModel : ViewModelBase
    {
        public Scheduling Scheduling { get; set; }
        public ICommand ScheduleCommand { get; set; }
        private const string URL_POST_SCHEDULING = "http://aluracar.herokuapp.com/salvaragendamento";

        
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

        public SchedulinViewModel(Vehicle vehicle,User user)
        {
            Scheduling = new Scheduling(user.nome, user.telefone, user.email, vehicle.Name, vehicle.Price);
            ScheduleCommand = new Command(
                () => { MessagingCenter.Send<Scheduling>(Scheduling, "Scheduling"); },
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
            DateTime DateHourScheduling = new DateTime(
                Scheduling.SchedulingDate.Year,
                Scheduling.SchedulingDate.Month,
                Scheduling.SchedulingDate.Day,
                Scheduling.SchedulingTime.Hours,
                Scheduling.SchedulingTime.Minutes,
                Scheduling.SchedulingTime.Seconds
                );

            var json = JsonConvert.SerializeObject(new
            {
                nome = Name,
                fone = Telephone,
                email = Email,
                carro = Scheduling.Model,
                preco = Scheduling.Price,
                data = DateHourScheduling

            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await new HttpClient().PostAsync(URL_POST_SCHEDULING, content);

            saveSchedulingDB();

            if (response.IsSuccessStatusCode)
            {
                MessagingCenter.Send<Scheduling>(Scheduling, "SuccessfulScheduling");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FailScheduling");
            }
        }

        private void saveSchedulingDB()
        {
            using (var connection = DependencyService.Get<IStorageble>().getConnection())
            {
                SchedulingDAO dao = new SchedulingDAO(connection);
                dao.save(new Scheduling(Name, Telephone, Email,Scheduling.Model,Scheduling.Price));
            }
        }
    }
}
