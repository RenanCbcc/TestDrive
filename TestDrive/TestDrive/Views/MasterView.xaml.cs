using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : TabbedPage
    {
        public MasterView(User user)
        {
            InitializeComponent();
            BindingContext = new MasterViewModel(user);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<User>(this, "EditPerfil", (user) =>
            {

                CurrentPage = Children[1];
            });

            MessagingCenter.Subscribe<User>(this, "SuccessfulSaveUser", (user) =>
            {
                CurrentPage = Children[0];
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<User>(this, "EditPerfil");
            MessagingCenter.Unsubscribe<User>(this, "SuccessfulSaveUser");
        }
    }
}