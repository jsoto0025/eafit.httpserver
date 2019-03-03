using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public class Response : IHttpResponse
    {
        public Protocol Protocol { get; set; }
        public Method Method { get; set; }
        public string Body { get; set; }
        public List<HttpHeader> Headers { get; set; }
        public string Version { get; set; }
        public string CodigoEstado { get; set; }
        public string DescripcionEstado { get; set; }

    }
}
