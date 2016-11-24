using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace N64Track.Data
{
    class JsonReaderN64
    {
        //using (StreamReader file = File.OpenText(@"C:\\Users\\hackmods\\Desktop\\Dave"));
        Assembly assembly;
        Stream stream;

        public JsonReaderN64()
        {
            /*
            List<Game> monkeys;
            using (var reader = new System.IO.StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(List<Monkey>));
                monkeys = (List<Monkey>)serializer.Deserialize(reader);
            }
            var listView = new ListView();
            listView.ItemsSource = monkeys;
            */
        }
        public string getData(string s)
        {
            assembly = typeof(Game).GetTypeInfo().Assembly;
            if (s == null)
                s = "N64Track.Data.n64db.json";

            stream = assembly.GetManifestResourceStream(s);

            string gameString = "";

            using (StreamReader sr = new StreamReader(stream))
            {
                gameString = sr.ReadToEnd();
                JsonTextReader reader = new JsonTextReader(new StringReader(gameString));
                //var game = JsonConvert.DeserializeObject<Game>(reader.Value);

                string result = "";

                while (reader.Read())
                {
                    if (reader.Value == null)
                    {
                        continue;
                    }
                    else
                    {
                        //build the object
                        Game game = new Game();
                        for (int i = 0; i < 9; i++)
                        {
                            if (i == 0 && reader.Value != null)
                                game.Name = reader.Value.ToString();
                            if (i == 1 && reader.Value != null)
                                game.Year = reader.Value.ToString();
                            if (i == 2 && reader.Value != null)
                                game.Developer = reader.Value.ToString();
                            if (i == 3 && reader.Value != null)
                                game.Publisher = reader.Value.ToString();
                            if (i == 4 && reader.Value != null)
                                game.Region = reader.Value.ToString();
                            if (i == 5 && reader.Value != null)
                                game.Players = reader.Value.ToString();
                            if (i == 6 && reader.Value != null)
                                game.ESRB = reader.Value.ToString();
                            if (i == 7 && reader.Value != null)
                                game.Genre = reader.Value.ToString();
                            if (i == 8 && reader.Value != null)
                                game.URL = reader.Value.ToString();

                            //result += reader.Value + " ";
                            if (i != 9) //dont read if it is the last one
                                reader.Read();
                        }
                        //for one object
                        //      return result;
                        App.Database.SaveGame(game);

                    }

                }
                //for all records, getting exception (when using object instead of printing)
                //return result;
            }
            return "";
        }
    }
}
