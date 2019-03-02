using HttpServer.RequestParser;
using System;
using HttpServer.Processing;

namespace HttpServer
{
    public class Server
    {
        private readonly Pipeline _pipeline;

        private Pipeline Pipeline => _pipeline;

        public Server()
        {
            _pipeline = new Pipeline();
        }


        public void Start()
        {
            var request = new Request();

            Pipeline.Start(request);
        }

    }
}
