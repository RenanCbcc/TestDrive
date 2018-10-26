using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TestDrive.Interfaces
{
    public interface IStorageble
    {
       SQLiteConnection getConnection();
    }
}
