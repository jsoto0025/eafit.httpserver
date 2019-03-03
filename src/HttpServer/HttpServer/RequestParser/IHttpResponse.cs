using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    /// <summary>
    /// Interface que representa una respueta HTTP
    /// </summary>
    public interface IHttpResponse : IHttpMessage
    {
        string StatusCode { get; set; }
        string StatusDescription { get; set; }
    }
}
