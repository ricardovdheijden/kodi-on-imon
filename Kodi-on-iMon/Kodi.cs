using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kodi_on_iMon
{
    public class Kodi
    {
        public Kodi()
        {

        }

        public KodiGetItem getItem()
        {
            WebClient webClient = new WebClient();
            //string json = "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetItem\", \"params\": { \"properties\": [\"title\", \"album\", \"artist\", \"season\", \"episode\", \"duration\", \"showtitle\", \"tvshowid\", \"thumbnail\", \"file\", \"fanart\", \"streamdetails\"], \"playerid\": 1 }, \"id\": \"VideoGetItem\"}";
            string json = "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetItem\", \"params\": { \"properties\": [\"title\", \"album\", \"season\", \"episode\", \"duration\", \"showtitle\", \"tvshowid\", \"file\"], \"playerid\": 1 }, \"id\": \"VideoGetItem\"}";
            string response = webClient.UploadString("http://localhost:8080/jsonrpc", "POST", json);

            KodiGetItem kodiResponse = JsonConvert.DeserializeObject<KodiGetItem>(response);

            return kodiResponse;
            //return response;
        }

        public KodiGetProperties getProperties()
        {
            WebClient webClient = new WebClient();
            string json = "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetProperties\",\"id\":1,\"params\":{\"playerid\":1,\"properties\":[\"playlistid\",\"speed\",\"position\",\"totaltime\",\"time\"]}}";
            string response = webClient.UploadString("http://localhost:8080/jsonrpc", "POST", json);

            KodiGetProperties kodiResponse = JsonConvert.DeserializeObject<KodiGetProperties>(response);

            return kodiResponse;
            //return response;
        }

        public KodiActivePlayers getActivePlayers()
        {
            WebClient webClient = new WebClient();
            //string json = "{\"jsonrpc\": \"2.0\", \"method\": \"Application.GetProperties\", \"params\": {\"properties\": [\"volume\"]}, \"id\": 1}";
            string json = "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetActivePlayers\", \"id\": 1}";
            string response = webClient.UploadString("http://localhost:8080/jsonrpc", "POST", json);

            KodiActivePlayers kodiResponse = JsonConvert.DeserializeObject<KodiActivePlayers>(response);

            return kodiResponse;
        }
    }

    public class KodiActivePlayers
    {
        public int id { get; set; }
        public string jsonrpc { get; set; }
        public KodiResult[] result { get; set; }
    }

    public class KodiGetItem
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public KodiResult result { get; set; }
    }

    public class KodiResult
    {
        public int playerid { get; set; }
        public string type { get; set; }
        public KodiItem item { get; set; }
    }

    public class KodiItem
    {
        public string album { get; set; }
        public int episode { get; set; }
        public string file { get; set; }
        public string label { get; set; }
        public int season { get; set; }
        public string showtitle { get; set; }
        public string title { get; set; }
        public int tvshowid { get; set; }
        public string type { get; set; }
    }

    public class KodiGetProperties
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public KodiGetPropertiesResult result { get; set; }
    }

    public class KodiGetPropertiesResult
    {
        public int playlistid { get; set; }
        public int position { get; set; }
        public int speed { get; set; }
        public KodiTime time { get; set; }
        public KodiTime totaltime { get; set; }
    }

    public class KodiTime
    {
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public string ToString()
        {
            return hours+":"+minutes+":"+seconds;
        }
    }
}
