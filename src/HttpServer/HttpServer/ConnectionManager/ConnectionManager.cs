using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.ConnectionManager
{
    /// <summary>
    /// Conexión al cliente
    /// </summary>
    public class ConnectionManager
    {
        private const int MAX_SIZE = 1000;
        /// <summary>
        /// Devuelve el string ASCII del request del client 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        internal string ObtainRequestString(TcpClient client)
        {
            var result = new Byte[MAX_SIZE];
            var stream = client.GetStream();
            int size = stream.Read(result, 0, result.Length);
            return Encoding.ASCII.GetString(result, 0, size);
        }

        /// <summary>
        /// Envia el stream de retorno al cliente que incio la solicitud inicial
        /// </summary>
        /// <param name="client">Cliente Tcp que contiene la información del cliente que realiza la peticicón</param>
        /// <param name="rawResponse">String con el mensaje que se envia de respuesta al cliente</param>
        internal void SendResponse(TcpClient client, string rawResponse)
        {
            var stream = client.GetStream();

            byte[] message = Encoding.ASCII.GetBytes(rawResponse);
            stream.Write(message, 0, message.Length);
        }
    }
}
