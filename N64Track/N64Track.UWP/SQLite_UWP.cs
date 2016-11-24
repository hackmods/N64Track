using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Xamarin.Forms;
using Windows.Storage;
using N64Track;
using N64Track.UWP;
using SQLite;

[assembly: Dependency(typeof(SQLite_UWP))]

namespace N64Track.UWP
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }

        #region ISQLite implementation
        /*  public SQLite.SQLiteConnection GetConnection()
          {
              var sqliteFilename = "WineAwakening.db3";
              string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

              var conn = new SQLite.SQLiteConnection(path);

              // Return the database connection 
              return conn;
          } */

        SQLiteConnection ISQLite.GetConnection()
        {
            var sqliteFilename = "n64.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
        #endregion
    }
}
