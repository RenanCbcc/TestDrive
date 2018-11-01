using System.Collections.ObjectModel;
using System.Linq;
using TestDrive.Interfaces;
using TestDrive.models;
using TestDrive.Persistence;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    class SchedulingsListViewModel : ViewModelBase
    {
        private ObservableCollection<Scheduling> _list;
        public ObservableCollection<Scheduling> List { get { return _list; } private set { _list = value; OnPropertyChanged(); } }

        private Scheduling _selectedScheduling;
        public Scheduling SelectedScheduling
        {
            get { return _selectedScheduling; }
            set
            {
                if (value != null)
                {
                    _selectedScheduling = value;
                    MessagingCenter.Send<Scheduling>(_selectedScheduling, "SaveSelectedScheduling");
                }
            }
        }

    public SchedulingsListViewModel()
        {
            List = new ObservableCollection<Scheduling>();
            UpdateList();

        }

        public void UpdateList()
        {
            using (var connection = DependencyService.Get<IStorageble>().getConnection())
            {
                SchedulingDAO dao = new SchedulingDAO(connection);
                var listDB = dao.List;
                var querry = listDB.OrderBy(schedule => schedule.SchedulingDate).ThenBy(schedule => schedule.SchedulingTime);
                List.Clear();
                foreach (var itemDB in listDB)
                {
                    List.Add(itemDB);
                }
            }
        }
    }
}
