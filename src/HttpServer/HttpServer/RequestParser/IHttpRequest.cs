using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public interface IHttpRequest : IHttpMessage
    {
        string Host { get; set; }
        string Port { get; set; }
        string Path { get; set; }
    }
}
