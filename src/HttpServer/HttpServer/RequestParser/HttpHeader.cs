using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    /// <summary>
    /// Clase que representa un encabezado HTTP
    /// </summary>
    public class HttpHeader
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public HttpHeader(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}