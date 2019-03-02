using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing
{
    public class ValidationProcessor2 : IProcessor
    {
        public void ProcessRequest(IHttpMessage httpMessage, Action<IHttpMessage> next, Action<IHttpMessage> stopProcessing)
        {
            Console.WriteLine("Processor 2");
            next(httpMessage);
        }

        public void ProcessResponse(IHttpMessage httpMessage)
        {
            Console.WriteLine("Reponse at processor 2");

            // Litterally do nothing here
        }
    }
}
