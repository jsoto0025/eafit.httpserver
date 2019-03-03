using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    /// <summary>
    /// Interface que representa un mensaje HTTP
    /// </summary>
    public interface IHttpMessage
    {
        Protocol Protocol { get; set; }
        string Body { get; set; }
        List<HttpHeader> Headers { get; set; }
        string Version { get; set; }
    }
}
