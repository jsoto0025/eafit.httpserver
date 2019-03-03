using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    /// <summary>
    /// Objeto de respuesta de HTTP
    /// </summary>
    public class Response : IHttpResponse
    {
        public Response()
        {
            Headers = new List<HttpHeader>();
        }

        public Protocol Protocol { get; set; }
        public string Body { get; set; }
        public List<HttpHeader> Headers { get; set; }
        public string Version { get; set; }
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
}
