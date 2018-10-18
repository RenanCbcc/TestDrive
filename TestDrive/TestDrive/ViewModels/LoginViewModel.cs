using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class LoginViewModel
    {
        public ICommand LoginCommand { get; set; }
        private string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        private string _password;
        public string Passsword
        {
            get { return _password; }
            set
            {
                _password = value;
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        private bool isItCharging;
        public bool Wait
        {
            get { return isItCharging; }
            set
            {
                isItCharging = value;
               // OnPropertyChanged();

            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                await login();
            }, () => { return (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password)); }
            );
        }

        private async System.Threading.Tasks.Task login()
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string,string>("email",_username),
                        new KeyValuePair<string,string>("senha",_password)
                    });
                var result = await client.PostAsync("https://aluracar.herokuapp.com/login", content);
                if (result.IsSuccessStatusCode)
                {
                    MessagingCenter.Send<User>(new User(_username, _password), "SuccessfulLogin");
                }
                else
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Login ou senha incorretos"), "FailLogin");
                }

            }
        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
