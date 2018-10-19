using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; private set; }
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

        private bool _isItLoging;
        public bool Loging
        {
            get { return _isItLoging; }
            set
            {
                _isItLoging = value;
                OnPropertyChanged();

            }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                Loging = true;
                await login();
                Loging = false;
            }, () => { return (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password)); }
            );
        }

        private async Task login()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = null;
                var content = new FormUrlEncodedContent(new[]
                {
                        new KeyValuePair<string,string>("email",_username),
                        new KeyValuePair<string,string>("senha",_password)
                    });

                try
                {
                    result = await client.PostAsync("https://aluracar.herokuapp.com/login", content);
                }
                catch
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Ocorreu um erro durante a conexão com o servidor."), "FailLogin");
                }

                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsStringAsync();
                    var resultofLogin = JsonConvert.DeserializeObject<ResultOfLogin>(data);
                    MessagingCenter.Send<User>(resultofLogin.usuario, "SuccessfulLogin");
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
