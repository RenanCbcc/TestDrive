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
    }
}