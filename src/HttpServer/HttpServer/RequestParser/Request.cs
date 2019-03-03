using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public class Request : IHttpRequest
    {
        public Protocol Protocol { get; set; }
        public Method Method { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Path { get; set; }
        public string Version { get; set; }
        public string Body { get; set; }
        public List<HttpHeader> Headers { get; set; }
        public string RawRequest { get; set; }

        public Request()
        {
            Headers = new List<HttpHeader>();
        }
    }
}
