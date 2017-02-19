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
        private string jsonVideoRequest = "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetItem\", \"params\": { \"properties\": [\"title\", \"album\", \"season\", \"episode\", \"duration\", \"showtitle\", \"tvshowid\", \"file\"], \"playerid\": 1 }, \"id\": \"VideoGetItem\"}";
        private string jsonAudioRequest = "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetItem\",\"params\":[0,[\"title\",\"file\",\"artist\",\"year\",\"album\",\"track\",\"duration\"]],\"id\": \"AudioGetItem\"}";
        private string jsonPictureRequest = "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetItem\",\"params\":[2,[\"file\"]],\"id\": \"PictureGetItem\"}";
        private string jsonPropertiesRequest = "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetProperties\",\"id\":1,\"params\":{\"playerid\":1,\"properties\":[\"playlistid\",\"speed\",\"position\",\"totaltime\",\"time\"]}}";
        private string jsonActivePlayersRequest = "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetActivePlayers\", \"id\": 1}";

        public KodiResponse getVideoItem()
        {
            string response = jsonRpcPost(jsonVideoRequest);
            KodiResponse kodiResponse = JsonConvert.DeserializeObject<KodiResponse>(response);
            return kodiResponse;
        }

        public KodiResponse getAudioItem()
        {
            string response = jsonRpcPost(jsonAudioRequest);
            KodiResponse kodiResponse = JsonConvert.DeserializeObject<KodiResponse>(response);
            return kodiResponse;
        }

        public KodiResponse getPictureItem()
        {
            string response = jsonRpcPost(jsonPictureRequest);
            KodiResponse kodiResponse = JsonConvert.DeserializeObject<KodiResponse>(response);
            return kodiResponse;
        }

        public KodiGetProperties getProperties()
        {
            string response = jsonRpcPost(jsonPropertiesRequest);
            KodiGetProperties kodiResponse = JsonConvert.DeserializeObject<KodiGetProperties>(response);
            return kodiResponse;
        }

        public KodiActivePlayers getActivePlayers()
        {
            string response = jsonRpcPost(jsonActivePlayersRequest);
            KodiActivePlayers kodiResponse = JsonConvert.DeserializeObject<KodiActivePlayers>(response);
            return kodiResponse;
        }

        // get methods with json as output
        public string getVideoItemJson()
        {
            return jsonRpcPost(jsonVideoRequest);
        }

        public string getAudioItemJson()
        {
            return jsonRpcPost(jsonAudioRequest);
        }

        public string getPictureItemJson()
        {
            return jsonRpcPost(jsonPictureRequest);
        }

        // method that connects with jsonrpc of Kodi
        public string jsonRpcPost(string input)
        {
            WebClient webClient = new WebClient();
            string response = "";
            try
            {
                response = webClient.UploadString("http://localhost:8080/jsonrpc", "POST", input);
            }
            catch (System.Net.WebException) 
            {
                response = "{\"error\": \"connectionError\"}";
            }
            
            return response;
        }
    }
    /*
     * Classes to convert json output into
     */
    public class KodiActivePlayers
    {
        public string error { get; set; }
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public KodiResult[] result { get; set; }
    }

    public class KodiResponse
    {
        public string error { get; set; }
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public KodiResult result { get; set; }
    }

    public class KodiGetProperties
    {
        public string error { get; set; }
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public KodiResult result { get; set; }
    }

    /*
     * Classes containing the reaults from json queries
     */
    public class KodiResult
    {
        public int playerid { get; set; }
        public string type { get; set; }
        public int playlistid { get; set; }
        public int position { get; set; }
        public int speed { get; set; }
        public KodiItem item { get; set; }
        public KodiTime time { get; set; }
        public KodiTime totaltime { get; set; }
    }

    public class KodiItem
    {
        public string album { get; set; }
        public string[] artist { get; set; }
        public int duration { get; set; }
        public int episode { get; set; }
        public string file { get; set; }
        public int id { get; set; }
        public string label { get; set; }
        public int season { get; set; }
        public string showtitle { get; set; }
        public string title { get; set; }
        public int track { get; set; }
        public int tvshowid { get; set; }
        public string type { get; set; }
        public int year { get; set; }
    }

    public class KodiTime
    {
        public int hours { get; set; }
        public int milliseconds { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public string ToString()
        {
            string result = hours + ":";

            if (minutes < 10) result += "0" + minutes;
            else result += minutes;
            result += ":";

            if (seconds < 10) result += "0" + seconds;
            else result += seconds;

            return result;
        }
    }
}
