using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    class HttpHeader
    {
        private string key;
        private string value;

      

        public string Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }

        public HttpHeader(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string headerstring()
        {
            string cadena="";

            return cadena=key.ToString()+ ": " + value.ToString() + " \r\n";
        }
    }
}
.