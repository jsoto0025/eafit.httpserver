using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing
{
    public class ValidationProcessor : IProcessor
    {
        public void ProcessRequest(IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing)
        {
            Console.WriteLine("Processor 1");

            next(request);
        }

        public void ProcessResponse(IHttpResponse response)
        {
            Console.WriteLine("Reponse at processor 1");

            // Litterally do nothing here
        }
    }
}
