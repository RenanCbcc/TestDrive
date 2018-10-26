using SQLite;
using System.IO;
using TestDrive.Droid;
using TestDrive.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]
namespace TestDrive.Droid
{
    class SQLiteAndroid : IStorageble
    {
        private const string fileNameDB = "scheduling.db3";

        public SQLiteConnection getConnection()
        {
            var pathDB = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, fileNameDB);

            return new SQLiteConnection(pathDB);
        }
    }
}