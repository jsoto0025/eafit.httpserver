using System;
using HttpServer.RequestParser;
using HttpServer.Processing;
using HttpServer.Processing.Processors;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace HttpServer
{
    /// <summary>
    /// Componente de servidor el cual contiene la ejecucón principal del servidor HTTP
    /// </summary>
    public class Server
    {
        private const int MAX_SIZE = 1000;
        private const int PORT = 8080;

        private readonly Pipeline _pipeline;
        private readonly TcpListener _listener;

        /// <summary>
        /// Constructor que inicializa el listado de los procesadores del pipeline
        /// </summary>
        public Server()
        {
            _pipeline = new Pipeline();

            _pipeline.AddProcessor(new DefaultResponseProcessor());
            _pipeline.AddProcessor(new LoggerProcessor());

            _listener = new TcpListener(IPAddress.Any, PORT);
        }


        /// <summary>
        /// Método que inicia la ejecucón del servidor
        /// </summary>
        public void Start()
        {

            try
            {
                _listener.Start();

                while (true)
                {
                    Console.WriteLine( HttpServerResources.ServerStatusMessageLines );

                    Console.WriteLine(HttpServerResources.ServerStatusMessageWait);

                    var client = _listener.AcceptTcpClient();

                    Console.WriteLine(HttpServerResources.ServerStatusMessageRecibe);
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

                    Console.WriteLine(HttpServerResources.ServerStatusMessageClose);
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
