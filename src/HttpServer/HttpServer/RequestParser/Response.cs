using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public class Response : IHttpResponse
    {
        public Protocol Protocol { get; set; }
        public Method Method { get; set; }

        private string header;


        private string version;
       
        private string body;

        public string Version { get => version; set => version = "1.1"; }
        
        public string Body { get => body; set => body = value; }
        public string Header { get => header; set => header = "Content-Type: text/html"; }
    }
}
