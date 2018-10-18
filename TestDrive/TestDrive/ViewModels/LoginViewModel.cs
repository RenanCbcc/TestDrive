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
            set { _username = value; }
        }

        private string _password;
        public string Passsword
        {
            get { return _password; }
            set { _password = value; }
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(() =>
            {
                MessagingCenter.Send<User>(new User(_username, _password), "SuccessfulLogin");
            }
            );
        }

    }
}
