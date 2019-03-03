using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public interface IHttpMessage
    {
        Protocol Protocol { get; set; }
        string Body { get; set; }
        List<HttpHeader> Headers { get; set; }
        string Version { get; set; }
    }
}
