﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public class Request : IHttpRequest
    {
        public Protocol Protocol { get; set; }
        public Method Method { get; set; }

        // Definicion de variables miembro 
            private string host;
        private string port;
        private string path;
        private string version;
        private string headers; //************ Cambiar a la lista de Headers cuando se construya la clase
        private string body;

        public string Host { get => host; set => host = value; }
        public string Port { get => port; set => port = value; }
        public string Path { get => path; set => path = value; }
        public string Version { get => version; set => version = value; }
        public string Headers { get => headers; set => headers = value; }
        public string Body { get => body; set => body = value; }


    }
}
