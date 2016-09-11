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
            /*WebClient webClient = new WebClient();
            dynamic result = JsonValue.Parse(webClient.DownloadString("https://api.foursquare.com/v2/users/self?oauth_token=XXXXXXX"));
            Console.WriteLine(result.response.user.firstName);
             * http://localhost:8080/jsonrpc
            */

            WebClient webClient = new WebClient();
            string json = "{\"jsonrpc\": \"2.0\", \"method\": \"Application.GetProperties\", \"params\": {\"properties\": [\"volume\"]}, \"id\": 1}";
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
}
