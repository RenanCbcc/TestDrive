using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public ICommand LoginCommand { get; set; }
        public LoginView()
        {
            InitializeComponent();
            LoginCommand = new Command(() => { MessagingCenter.Send<User>(new User(), "SuccessfulLogin"); });
        }


    }
}