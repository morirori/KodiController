using KodiController.Utills;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiController.Kodi.KodiFunctions {
    class SelectFunction : IKodiFunction  {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public int id { get; set; }

        public void function() {
            try {
                RequestCreator rq = new RequestCreator();
                this.jsonrpc = "2.0";
                this.method = "Input.Select";
                this.id = 1;
                var json = JsonConvert.SerializeObject(this);
                var response = rq.executeGetRequest(json);
                var error = JsonConvert.DeserializeObject<ErrorMessage>(response);
                Console.WriteLine(error.error.message);
                if (error.error.message.Equals("")) {
                    Console.WriteLine(error.error.message);

                }
            }
            catch (NullReferenceException ex) {
                Console.WriteLine("Succes");
            }

        }

    }

}
