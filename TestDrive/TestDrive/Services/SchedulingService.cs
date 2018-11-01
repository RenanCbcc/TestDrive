using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TestDrive.Interfaces;
using TestDrive.models;
using TestDrive.Persistence;
using Xamarin.Forms;

namespace TestDrive.Services
{
    public class SchedulingService
    {
        private const string URL_POST_SCHEDULING = "http://aluracar.herokuapp.com/salvaragendamento";
        public async System.Threading.Tasks.Task SendScheduling(Scheduling scheduling)
        {
            DateTime DateHourScheduling = new DateTime(
                            scheduling.SchedulingDate.Year,
                            scheduling.SchedulingDate.Month,
                            scheduling.SchedulingDate.Day,
                            scheduling.SchedulingTime.Hours,
                            scheduling.SchedulingTime.Minutes,
                            scheduling.SchedulingTime.Seconds
                            );

            var json = JsonConvert.SerializeObject(new
            {
                nome = scheduling.Name,
                fone = scheduling.Telephone,
                email = scheduling.Email,
                carro = scheduling.Model,
                preco = scheduling.Price,
                data = DateHourScheduling

            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await new HttpClient().PostAsync(URL_POST_SCHEDULING, content);

            if (response.IsSuccessStatusCode)
            {
                scheduling.IsItScheduled = true;
                MessagingCenter.Send<Scheduling>(scheduling, "SuccessfulScheduling");
            }
            else
            {
                scheduling.IsItScheduled = false;
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FailScheduling");
            }
            //Saves the scheduling at database anyway.
            SaveSchedulingDB(scheduling);
        }

        private void SaveSchedulingDB(Scheduling scheduling)
        {
            using (var connection = DependencyService.Get<IStorageble>().getConnection())
            {
                SchedulingDAO dao = new SchedulingDAO(connection);
                dao.save(scheduling);
            }
        }
    }
}
