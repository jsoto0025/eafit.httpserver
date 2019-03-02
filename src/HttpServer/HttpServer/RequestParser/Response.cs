using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public class Response : IHttpResponse
    {
        public Protocol Protocol { get; set; }
        public Method Method { get; set; }
       

        private string version;
        private List<HttpHeader> headers; //Revisar 
        private string body;

        public string Version { get => version; set => version = "1.1"; }
        internal List<HttpHeader> Headers { get => headers; set => headers = value; }
        public string Body { get => body; set => body = value; }

        //Como asignar el objeto headerInterno que se sabe ira en la lista???
        private HttpHeader HeaderInterno = new HttpHeader("Content-Type:", "text/html");
        

    }
}
