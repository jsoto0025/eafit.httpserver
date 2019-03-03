using System;
using HttpServer.RequestParser;
using HttpServer.Processing;
using HttpServer.Processing.Processors;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace HttpServer
{
    public class Server
    {
        private const int MAX_SIZE = 1000;
        private const int PORT = 8080;

        private readonly Pipeline _pipeline;
        private readonly TcpListener _listener;

        public Server()
        {
            _pipeline = new Pipeline();

            _pipeline.AddProcessor(new DefaultResponseProcessor());
            _pipeline.AddProcessor(new LoggerProcessor());

            _listener = new TcpListener(IPAddress.Any, PORT);
        }


        public void Start()
        {

            try
            {
                _listener.Start();

                while (true)
                {
                    Console.WriteLine("--------------------------------");

                    Console.WriteLine("\r\nWating for connections......");

                    var client = _listener.AcceptTcpClient();

                    Console.WriteLine("\r\nConnection received");
                    Console.WriteLine();

                    var connectionManager = new ConnectionManager.ConnectionManager();

                    var rawRequest = connectionManager.ObtainRequestString(client);

                    var parser = new RequestParser.RequestParser();

                    if (!string.IsNullOrEmpty(rawRequest))
                    {
                        var request = parser.Parse(rawRequest);

                        var response = _pipeline.Run(request);
                        var rawResponse = parser.Serialize(response);

                        connectionManager.SendResponse(client, rawResponse);
                    }

                    client.Close();

                    Console.WriteLine("\r\nConnection close");
                }
            }
            finally
            {
                _listener.Stop();
            }
        }

        public void Stop()
        {
            _listener.Stop();
        }
    }
}
