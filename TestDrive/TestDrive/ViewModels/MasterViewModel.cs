using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel: ViewModelBase
    {
        private readonly User _user;
        public string Name { get { return _user.nome; } set { _user.nome = value; } }
        public string Email { get { return _user.email; } set { _user.email = value; } }
        public string Telefone { get { return _user.telefone; } set { _user.telefone = value; } }
        public string DataNascimento { get { return _user.dataNascimento; } set { _user.dataNascimento = value; } }

        public ICommand EditPerfilCommand { get; private set; }
        public ICommand SavePerfilCommand { get; private set; }
        public ICommand SaveEditedCommand { get; private set; }

        private bool isItEditing;

        public bool IsItEditing
        {
            get { return isItEditing; }
            set {
                isItEditing = value;
                OnPropertyChanged();
            }
        }

        public MasterViewModel(User user)
        {
            this._user = user;
            EditPerfilCommand = new Command(() => 
            {
                MessagingCenter.Send<User>(_user, "EditPerfil");
            });

            SavePerfilCommand = new Command(() => 
            {
                MessagingCenter.Send<User>(_user, "SuccessfulSaveUser");
            });

            SaveEditedCommand = new Command(() => 
            {
                isItEditing = true;
            });
        }
                     
    }
}
