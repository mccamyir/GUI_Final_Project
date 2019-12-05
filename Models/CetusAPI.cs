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
    public class CetusAPI
    {
        public bool isDay { get; set; }
        private string timeLeft { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }

        public CetusAPI()
        {
            CetusTime();
            ParseAPI();
        }

        private void ParseAPI()
        {

            string[] sentences;
            int APIseconds, APIminutes, APIhours;

            bool hasHour = timeLeft.Contains('h');
            bool hasMinute = timeLeft.Contains("m");
            sentences = timeLeft.Split(new Char[] { 'm', 's', ' ', 'h' });
            if (hasHour)
            {
                int.TryParse(sentences[0], out APIhours); //The Split creates an empty item between each substring, use only even items.
                int.TryParse(sentences[2], out APIminutes);
                int.TryParse(sentences[4], out APIseconds);
            }
            else if (hasMinute)
            {
                APIhours = 0;
                int.TryParse(sentences[0], out APIminutes);
                int.TryParse(sentences[2], out APIseconds);
            }
            else
            {
                APIhours = 0;
                APIminutes = 0;
                int.TryParse(sentences[0], out APIseconds);
            }
            hours = APIhours;
            minutes = APIminutes;
            seconds = APIseconds;
        }
        private void CetusTime()
        {
            string CetusURL = "https://api.warframestat.us/PC/cetusCycle";
            HttpClient client = new HttpClient();
            buffer API;
            using (Stream s = client.GetStreamAsync(CetusURL).Result)
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();

                // read the json from a stream
                // json size doesn't matter because only a small piece is read at a time from the HTTP request
                API = serializer.Deserialize<buffer>(reader);
            }
            timeLeft = API.timeLeft;
            isDay = API.isDay;
            ParseAPI();
        }

    }
}
