using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.ConnectionManager
{
    public class ConnectionManager
    {
        private const int MAX_SIZE = 1000;

        internal string ObtainRequestString(TcpClient client)
        {
            var result = new Byte[MAX_SIZE];
            var stream = client.GetStream();
            int size = stream.Read(result, 0, result.Length);
            return Encoding.ASCII.GetString(result, 0, size);
        }

        internal void SendResponse(TcpClient client, string rawResponse)
        {
            var stream = client.GetStream();

            byte[] message = Encoding.ASCII.GetBytes(rawResponse);
            stream.Write(message, 0, message.Length);
        }
    }
}
