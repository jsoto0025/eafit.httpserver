using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public interface IHttpResponse : IHttpMessage
    {
        string StatusCode { get; set; }
        string StatusDescription { get; set; }
    }
}
