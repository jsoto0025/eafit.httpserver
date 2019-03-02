using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing
{
    public class ValidationProcessor : IProcessor
    {
        public void ProcessRequest(IHttpMessage httpMessage, Action<IHttpMessage> next, Action<IHttpMessage> stopProcessing)
        {
            Console.WriteLine("Processor 1");

            next(httpMessage);
        }

        public void ProcessResponse(IHttpMessage httpMessage)
        {
            Console.WriteLine("Reponse at processor 1");

            // Litterally do nothing here
        }
    }
}
