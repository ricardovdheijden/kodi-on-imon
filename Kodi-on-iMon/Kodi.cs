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
        
        public string getTitle()
        {
            WebClient webClient = new WebClient();
            //string json = "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetItem\", \"params\": { \"properties\": [\"title\", \"album\", \"artist\", \"season\", \"episode\", \"duration\", \"showtitle\", \"tvshowid\", \"thumbnail\", \"file\", \"fanart\", \"streamdetails\"], \"playerid\": 1 }, \"id\": \"VideoGetItem\"}";
            string json = "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetItem\", \"params\": { \"properties\": [\"title\", \"album\", \"season\", \"episode\", \"duration\", \"showtitle\", \"tvshowid\", \"file\"], \"playerid\": 1 }, \"id\": \"VideoGetItem\"}";
            string response = webClient.UploadString("http://localhost:8080/jsonrpc", "POST", json);

            KodiResponse kodiResponse = JsonConvert.DeserializeObject<KodiResponse>(response);

            return kodiResponse.result.item.file;
            //return response;
        }

        public string getActivePlayers()
        {
            /*WebClient webClient = new WebClient();
           dynamic result = JsonValue.Parse(webClient.DownloadString("https://api.foursquare.com/v2/users/self?oauth_token=XXXXXXX"));
           Console.WriteLine(result.response.user.firstName);
            * http://localhost:8080/jsonrpc
           */

            WebClient webClient = new WebClient();
            //string json = "{\"jsonrpc\": \"2.0\", \"method\": \"Application.GetProperties\", \"params\": {\"properties\": [\"volume\"]}, \"id\": 1}";
            string json = "{\"jsonrpc\": \"2.0\", \"method\": \"Player.GetActivePlayers\", \"id\": 1}";
            string response = webClient.UploadString("http://localhost:8080/jsonrpc", "POST", json);

            return response;
        }

        public string getEmail()
        {
            string json2 = "{'Email': 'james@example.com','Active': true,'CreatedDate': '2013-01-20T00:00:00Z','Roles': ['User','Admin']}";
            Account account = JsonConvert.DeserializeObject<Account>(json2);

            return account.Email;
        }
    }

    //For test purposes: the json converter expects an object that matches with the json
    public class Account
    {
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }

    public class KodiResponse
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public KodiResult result { get; set; }
    }

    public class KodiResult
    {
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
}
