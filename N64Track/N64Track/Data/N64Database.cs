using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;

namespace N64Track
{
    public class N64Database
    {
        static object locker = new object();

        SQLiteConnection database;

        public N64Database()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            int check = CheckDBLoad();
            if (check < 2)
            {
                GenerateRecords g = new GenerateRecords();
                g.Create(database);
            }
        }

        public void Generate()
        {
                GenerateRecords g = new GenerateRecords();
                g.Generate(database);
        }

        public void ReGenerate()
        {
            GenerateRecords g = new GenerateRecords();
            g.Create(database);
        }

        public void Reset()
        {
            lock (locker)
            {
                database.Execute(" DELETE FROM game;");
            }
        }

        //checkifdbisloaded
        public int CheckDBLoad()
        {
            lock (locker)
            {
                try
                {
                    List<Game> game = new List<Game>();
                    game = (from i in database.Table<Game>() select i).ToList();
                    return game.Count;
                }
                catch (Exception e)
                {
                    var exception = e;
                    return 0;
                }
            }
        }

        //Game CRUD
        public IEnumerable<Game> GetGames()
        {
            lock (locker)
            {
                return (from i in database.Table<Game>() select i).ToList();
            }
        }

        public Game GetGame(int ID)
        {
            lock (locker)
            {
               return database.Table<Game>().FirstOrDefault(x => x.ID == ID);
                //return database.Query<Game>("SELECT * FROM [Game] WHERE [ID] = " + ID);
            }
        }

        public IEnumerable<Game> GetGameTypes()
        {
            lock (locker)
            {
                return database.Query<Game>("SELECT DISTINCT [Genre] FROM game;");
            }
        }

        public IEnumerable<Game> GetGameTypeOf(String type)
        {
            lock (locker)
            {
                return database.Query<Game>("SELECT* FROM game WHERE[Genre] = '" + type + "';");
            }
        }

        public int SaveGame(Game game)
        {
            lock (locker)
            {
                if (game.ID != 0)
                {
                    database.Update(game);
                    return game.ID;
                }
                else
                {
                    return database.Insert(game);
                }
            }
        }

        public int DeleteGame(int id)
        {
            lock (locker)
            { 
                return database.Delete<Game>(id);
            }
        }
    }

}

