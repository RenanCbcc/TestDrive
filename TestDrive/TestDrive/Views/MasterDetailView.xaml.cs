using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailView : MasterDetailPage
    {
        public MasterDetailView(User user)
        {
            InitializeComponent();
            Master = new MasterView(user);
            Detail = new NavigationPage(new ListingView(user));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<User>(this, "MySchedulings", (user) => 
            {
                this.Detail = new SchedulingsListView();
                ///Hides the MasterView immediately after the detail page is chosen.
                IsPresented = false;
            });
        }
    }
       
}