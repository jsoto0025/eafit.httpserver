using System;
using HttpServer.RequestParser;
using HttpServer.Processing;
using HttpServer.Processing.Processors;

namespace HttpServer
{
    public class Server
    {
        private readonly Pipeline _pipeline;

        public Server()
        {
            _pipeline = new Pipeline();

            _pipeline.AddProcessor(new ValidationProcessor());
            _pipeline.AddProcessor(new LoggerProcessor());
        }


        public void Start()
        {
            var request = new Request();

            _pipeline.Run(request);
        }

    }
}
