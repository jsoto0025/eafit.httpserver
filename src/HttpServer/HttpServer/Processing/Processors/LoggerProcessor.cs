using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing.Processors
{
    public class LoggerProcessor : IProcessor
    {
        public void ProcessRequest(IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing)
        {
            Console.WriteLine("Request at Logger");

            next(request);
        }

        public void ProcessResponse(IHttpResponse response)
        {
            Console.WriteLine("Reponse at Logger");

            // Litterally do nothing here
        }
    }
}
