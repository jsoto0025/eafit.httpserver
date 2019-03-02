using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public class Request : IHttpMessage
    {
        public Protocol Protocol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Method Method { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
