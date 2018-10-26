using SQLite;
using TestDrive.models;

namespace TestDrive.Persistence
{
    public class SchedulingDAO
    {
        private readonly SQLiteConnection _connection;

        public SchedulingDAO(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<Scheduling>();
        }

        public void save(Scheduling scheduling)
        {
            _connection.Insert(scheduling);
        }
    }
}
