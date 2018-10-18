using System;
using TestDrive.Models;
using TestDrive.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TestDrive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //I don't want my loginview as my root page.
            //MainPage = new NavigationPage(new LoginView());
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<User>(this, "SuccessfulLogin", (message) => { MainPage = new NavigationPage(new ListingView());});
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
