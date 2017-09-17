using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinectt.KodiFunctions {
    public class Error {
        public int code { get; set; }
        public string message { get; set; }

    }

    public class ErrorMessage {
        public Error error { get; set; }
        public int id { get; set; }
        public string jsonrpc { get; set; }

        ErrorMessage() {
            error = new Error();
        }
    }
}
