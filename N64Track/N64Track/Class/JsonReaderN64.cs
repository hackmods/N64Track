using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
        }
        async public void getData(string s)
        {
            assembly = typeof(Game).GetTypeInfo().Assembly;
            if (s == null)
                s = "N64Track.Data.n64db.json";

            stream = assembly.GetManifestResourceStream(s);


            string gameString = "";

            using (StreamReader sr = new StreamReader(stream))
            {
                
                //web method
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var address = $"http://zxcv.us/json/n64pal.json"; 
                var response = await client.GetAsync(address);
                //file
                if(s.Equals("N64Track.Data.n64jap.json"))
                {
                    gameString = sr.ReadToEnd();
                }
                //web
                if (s.Equals("N64Track.Data.n64pal.json"))
                {
                    gameString = response.Content.ReadAsStringAsync().Result;
                    
                }
                else //default to local style
                {
                    gameString = response.Content.ReadAsStringAsync().Result;
                }
                JsonTextReader reader = new JsonTextReader(new StringReader(gameString));
                //var game = JsonConvert.DeserializeObject<Game>(reader.Value);
                Game game = new Game();

                while (reader.Read())
                {
                    if (reader.Value == null)
                    {
                        continue;
                    }
                    else
                    {
                        //build the object
                        if (reader.Value.Equals("Name"))
                        { //&& reader.Value != null)
                            game = new Game();
                            if (reader.Read() && reader.Value != null)
                                game.Name = reader.Value.ToString();
                            continue;
                        }
                        if (reader.Value.Equals("Year"))
                        { //&& reader.Value != null)
                            if (reader.Read() && reader.Value != null)
                                game.Year = reader.Value.ToString();
                            continue;
                        }
                        if (reader.Value.Equals("Developer"))
                        { //&& reader.Value != null)
                            if (reader.Read() && reader.Value != null)
                                game.Developer = reader.Value.ToString();
                            continue;
                        }
                        if (reader.Value.Equals("Publisher"))
                        { //&& reader.Value != null)
                            if (reader.Read() && reader.Value != null)
                                game.Publisher = reader.Value.ToString();
                            continue;
                        }
                        if (reader.Value.Equals("Region"))
                        { //&& reader.Value != null)
                            if (reader.Read() && reader.Value != null)
                                game.Region = reader.Value.ToString();
                            continue;
                        }
                        if (reader.Value.Equals("Players"))
                        { //&& reader.Value != null)
                            if (reader.Read() && reader.Value != null)
                                game.Players = reader.Value.ToString();
                            continue;
                        }
                        if (reader.Value.Equals("ESRB"))
                        { //&& reader.Value != null)
                            if (reader.Read() && reader.Value != null)
                                game.ESRB = reader.Value.ToString();
                            continue;
                        }
                        if (reader.Value.Equals("Genre"))
                        { //&& reader.Value != null)
                            if (reader.Read() && reader.Value != null)
                                game.Genre = reader.Value.ToString();
                            continue;
                        }
                        if (reader.Value.Equals("URL"))
                        { //&& reader.Value != null)
                            if (reader.Read() && reader.Value != null)
                                game.URL = reader.Value.ToString();
                            App.Database.SaveGame(game);
                            continue;
                        }
                        //for one object
                        //      return result;
                    }

                }
                //for all records, getting exception (when using object instead of printing)
                //return result;
            }
            //return "";
        }
    }
}
