using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Final_Project.Model
{
    struct buffer
    {
        public string timeLeft { get; set; }
        public bool isWarm { get; set; }
        public bool isDay { get; set; }
    }
    public class FortunaAPI
    {
        private string timeLeft { get; set; }
        public bool isWarm { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }

        public FortunaAPI()
        {
            FortunaTime();
            ParseAPI();
        }
        private void ParseAPI()
        {
            string[] sentences;
            int APIseconds, APIminutes;

            bool hasMinute = timeLeft.Contains("m");
            sentences = timeLeft.Split(new Char[] { 'm', 's', ' ' });
            if (hasMinute)
            {
                int.TryParse(sentences[0], out APIminutes); //The Split creates an empty item between each substring, use only even items.
                int.TryParse(sentences[2], out APIseconds);
            }
            else
            {
                int.TryParse(sentences[0], out APIseconds);
                APIminutes = 0;
            }
            minutes = APIminutes;
            seconds = APIseconds;
        }
        private void FortunaTime()
        {
            string FortunaURL = "https://api.warframestat.us/PC/vallisCycle";
            HttpClient client = new HttpClient();
            buffer API;
            using (Stream s = client.GetStreamAsync(FortunaURL).Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                // read the json from a stream
                // json size doesn't matter because only a small piece is read at a time from the HTTP request
                API = serializer.Deserialize<buffer>(reader);
            }
            timeLeft = API.timeLeft;
            isWarm = API.isWarm;
            ParseAPI();
        }
    }
}
