using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public interface IHttpMessage
    {
        Protocol Protocol { get; set; }
        Method Method { get; set; }
    }
}
