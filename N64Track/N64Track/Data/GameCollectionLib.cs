using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N64Track
{
    public class GameCollectionLib
    {
        public GameViewModel MyGame;
        public List<Game> MyGameFilter;

        public String filter = "-1";
        public GameCollectionLib()
        {
            List<Game> GameList;

            GameList = App.Database.GetGames().ToList();
            MyGame = new GameViewModel(GameList);
        }

        public Game UpdateGame(Game Game)
        {
            int r = App.Database.SaveGame(Game);
            if (Game.ID == 0)
                Game.ID = r;

            var obItem = MyGame.Games.FirstOrDefault(i => i.ID == Game.ID);
            if (obItem != null)
            {
                obItem = Game;
            }
            else
            {
                MyGame.Games.Add(Game);
            }
            return Game;
        }

        public void RemoveGame(Game Game)
        {
            var obItem = MyGame.Games.FirstOrDefault(i => i.ID == Game.ID);
            if (obItem != null)
            {
                MyGame.Games.Remove(obItem);
                App.Database.DeleteGame(Game.ID);
            }
        }

        //get Ratings
        public String[] GenreList()
        {
            //create dictionary
            String[] list = new String[0];
            // var obItem = MyGame.Games.FirstOrDefault(i => i.ID == Game.ID);

            for (int i = 0; i < list.Count(); i++)
            {
                //build list
            }
            return list;
        }
    }
}