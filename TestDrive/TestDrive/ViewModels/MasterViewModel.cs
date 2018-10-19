using TestDrive.Models;

namespace TestDrive.ViewModels
{
    public class MasterViewModel
    {
        private readonly User _user;
        public string Name { get { return _user.nome; } set { _user.nome = value; } }
        public string Email { get { return _user.email; } set { _user.email = value; } }

        public MasterViewModel(User user)
        {
            this._user = user;
        }
                     
    }
}
