﻿using Newtonsoft.Json;
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
        private string jsonActivePlayersRequest() { return "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetActivePlayers\", \"id\": 1}"; }
        private string jsonVideoRequest(int playerid) { return "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetItem\", \"params\": { \"properties\": [\"title\", \"album\", \"artist\", \"season\", \"episode\", \"duration\", \"showtitle\", \"tvshowid\", \"file\", \"year\"], \"playerid\": " + playerid + " }, \"id\": \"VideoGetItem\"}"; }
        private string jsonAudioRequest(int playerid) { return "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetItem\",\"params\":[" + playerid + ",[\"title\",\"file\",\"artist\",\"year\",\"album\",\"track\",\"duration\"]],\"id\": \"AudioGetItem\"}"; }
        private string jsonPictureRequest(int playerid) { return "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetItem\",\"params\":[" + playerid + ",[\"file\"]],\"id\": \"PictureGetItem\"}"; }
        private string jsonPropertiesRequest(int playerid) { return "{\"jsonrpc\":\"2.0\",\"method\":\"Player.GetProperties\",\"id\":1,\"params\":{\"playerid\":" + playerid + ",\"properties\":[\"playlistid\",\"speed\",\"position\",\"totaltime\",\"time\"]}}"; }


        public KodiResponse getVideoItem(int playerid)
        {
            string response = jsonRpcPost(jsonVideoRequest(playerid));
            KodiResponse kodiResponse = JsonConvert.DeserializeObject<KodiResponse>(response);
            return kodiResponse;
        }

        public KodiResponse getAudioItem(int playerid)
        {
            string response = jsonRpcPost(jsonAudioRequest(playerid));
            KodiResponse kodiResponse = JsonConvert.DeserializeObject<KodiResponse>(response);
            return kodiResponse;
        }

        public KodiResponse getPictureItem(int playerid)
        {
            string response = jsonRpcPost(jsonPictureRequest(playerid));
            KodiResponse kodiResponse = JsonConvert.DeserializeObject<KodiResponse>(response);
            return kodiResponse;
        }

        public KodiGetProperties getProperties(int playerid)
        {
            string response = jsonRpcPost(jsonPropertiesRequest(playerid));
            KodiGetProperties kodiResponse = JsonConvert.DeserializeObject<KodiGetProperties>(response);
            return kodiResponse;
        }

        public KodiActivePlayers getActivePlayers()
        {
            string response = jsonRpcPost(jsonActivePlayersRequest());
            KodiActivePlayers kodiResponse = JsonConvert.DeserializeObject<KodiActivePlayers>(response);
            return kodiResponse;
        }

        // get methods with json as output
        public string getVideoItemJson(int playerid)
        {
            return jsonRpcPost(jsonVideoRequest(playerid));
        }

        public string getAudioItemJson(int playerid)
        {
            return jsonRpcPost(jsonAudioRequest(playerid));
        }

        public string getPictureItemJson(int playerid)
        {
            return jsonRpcPost(jsonPictureRequest(playerid));
        }

        public string getPropertiesJson(int playerid)
        {
            return jsonRpcPost(jsonPropertiesRequest(playerid));
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
                response = "{\"error\": \"Connection Error\"}";
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
        public string movieToString()
        {
            string result = title + " (" + year + ")";
            return result;
        }
        public string episodeToString()
        {
            string result = showtitle + " - S";
            if (season < 10) result += "0" + season;
            else result += season;
            result += "E";
            if (episode < 10) result += "0" + episode;
            else result += episode;
            result += " - " + title;
            return result;
        }
        public string musicvideoToString()
        {
            string result = "";
            for (int i = 0; i < artist.Length; i++)
            {
                result += artist[i];
                if (i < artist.Length - 1) result += ", ";
            }
            result += " - " + title;
            return result;
        }
        public string songToString()
        {
            string result = "";
            for (int i = 0; i < artist.Length; i++)
            {
                result += artist[i];
                if (i < artist.Length - 1) result += ", ";
            }
            result += " - " + title;
            return result;
        }
        public string pictureToString()
        {
            return label;
        }
        public string unknownTypeToString()
        {
            return label;
        }
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
