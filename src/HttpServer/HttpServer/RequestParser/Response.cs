using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public class Response : IHttpResponse
    {
        public Protocol Protocol { get; set; }
        public Method Method { get; set; }
    }
}
