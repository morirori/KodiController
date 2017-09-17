using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kinectt {
    class RequestCreator {
        private string url = "http://localhost:8080/jsonrpc";
        WebClient webClient;

       public RequestCreator() {
            webClient = new WebClient();
        }

        public string executePostRequest(String json) { 
            var response = webClient.UploadString(url, "POST", json);
            return response;
        }

        public string executeGetRequest(String json) {
            var response = webClient.UploadString(url, "POST", json);
            return response;
        }

    }
}
