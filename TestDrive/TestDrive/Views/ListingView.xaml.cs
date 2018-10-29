using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using TestDrive.models;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public partial class ListingView : ContentPage
    {
        public ListingViewModel ViewModel { get; set; }
        private readonly User _user;

        public ListingView(User user)
        {
            InitializeComponent();
            _user = user;
            ViewModel = new ListingViewModel();
            BindingContext = ViewModel;
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                {
                    await DisplayAlert("Acesso a Armazenamento Externo", "É preciso dar permissão para Armazenamento Externo", "OK");
                }

                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
                status = results[Permission.Storage];
            }

            if (status == PermissionStatus.Granted)
            {
                //var conexao = new BancoDadosDB();
                await ViewModel.getVehicles();
                MessagingCenter.Subscribe<Vehicle>(this, "SelectedVehicle", (vehicle) =>
                {
                    Navigation.PushAsync(new ItemDetailView(vehicle, _user));
                });
            }
            else if (status != PermissionStatus.Unknown)
            {
                await DisplayAlert("Armazenamento Externo Negado", "Não é possível continuar", "OK");
            }
            

                               }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Vehicle>(this, "SelectedVehicle");
        }
    }
}
