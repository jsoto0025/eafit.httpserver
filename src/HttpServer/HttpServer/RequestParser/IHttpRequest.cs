using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    /// <summary>
    /// Interface que representa un HTTP request 
    /// </summary>
    public interface IHttpRequest : IHttpMessage
    {
        Method? Method { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string Path { get; set; }
        string RawRequest { get; set; }
    }
}
