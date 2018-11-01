using SQLite;
using System.Collections.Generic;
using TestDrive.models;

namespace TestDrive.Persistence
{
    public class SchedulingDAO
    {
        private readonly SQLiteConnection _connection;
        private List<Scheduling> _list;
        public List<Scheduling> List
        {
            get { return _connection.Table<Scheduling>().ToList(); }
            private set { _list = value; }
        }

        public SchedulingDAO(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Scheduling>();
        }

        public void save(Scheduling scheduling)
        {
            if (_connection.Find<Scheduling>(scheduling.ID) == null)
            {
                _connection.Insert(scheduling);
            }
            else
            {
                _connection.Update(scheduling);
            }
        }

    }
}
