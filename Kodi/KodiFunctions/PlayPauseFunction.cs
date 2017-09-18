
using KodiController.Utills;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiController.Kodi.KodiFunctions  {
    class PlayPauseFunction : IKodiFunction {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public Params @params { get; set; }
        public int id { get; set; }
        public PlayPauseFunction() {
            @params = new Params();
        }
       
        public void function() {
            try {
                RequestCreator rq = new RequestCreator();
                this.jsonrpc = "2.0";
                this.method = "Player.GetActivePlayers";
                this.id = 1;
                var json = JsonConvert.SerializeObject(this);
                var response = rq.executeGetRequest(json);
                var dict = JsonConvert.DeserializeObject<PlayPauseFunction>(response);
                Params para = new Params();
                if (response != null) {
                    this.method = "Player.PlayPause";
                    this.@params.playerid = dict.@params.playerid;
                    json = JsonConvert.SerializeObject(this);
                    var request = rq.executePostRequest(json);
                    var possibleError = JsonConvert.DeserializeObject<ErrorMessage>(request);      
                    Console.WriteLine(possibleError.error.message);
                }
            }
            catch (NullReferenceException ex) { } 
        } 
    }
    
}

    public class Params {
        public int playerid { get; set; }

        public static implicit operator Params(int v) {
            throw new NotImplementedException();
        }
    }

