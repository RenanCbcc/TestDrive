using System.Collections.ObjectModel;
using TestDrive.Interfaces;
using TestDrive.models;
using TestDrive.Persistence;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    class SchedulingsListViewModel: ViewModelBase
    {
        private ObservableCollection<Scheduling> _list;
        public ObservableCollection<Scheduling> List { get { return _list; } private set { _list = value; OnPropertyChanged(); } }

        public SchedulingsListViewModel()
        {
            List = new ObservableCollection<Scheduling>();
            using (var connection = DependencyService.Get<IStorageble>().getConnection())
            {
                SchedulingDAO dao = new SchedulingDAO(connection);
               var listDB = dao.List;
                List.Clear();
                foreach (var itemDB in listDB)
                {
                    List.Add(itemDB);
                }
            }
               
        }
    }    
}
