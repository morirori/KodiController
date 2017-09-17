using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinectt.KodiFunctions {
    class LeftFunction : IKodiFunction {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public int id { get; set; }


        public void function() {
            try {
                RequestCreator rq = new RequestCreator();
                this.jsonrpc = "2.0";
                this.method = "Input.Left";
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

    class RightFunction : IKodiFunction {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public int id { get; set; }


        public void function() {
            try {
                RequestCreator rq = new RequestCreator();
                this.jsonrpc = "2.0";
                this.method = "Input.Right";
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

    class UpFunction : IKodiFunction {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public int id { get; set; }


        public void function() {
            try {
                RequestCreator rq = new RequestCreator();
                this.jsonrpc = "2.0";
                this.method = "Input.Up";
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

    class DownFunction : IKodiFunction {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public int id { get; set; }


        public void function() {
            try {
                RequestCreator rq = new RequestCreator();
                this.jsonrpc = "2.0";
                this.method = "Input.Down";
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


