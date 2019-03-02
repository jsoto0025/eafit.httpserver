using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing
{
    public class LoggerProcessor : IProcessor
    {
        public void ProcessRequest(IHttpRequest httpMessage, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing)
        {
            Console.WriteLine("Request at Logger");
            next(httpMessage);
        }

        public void ProcessResponse(IHttpResponse httpMessage)
        {
            Console.WriteLine("Reponse at Logger");

            // Litterally do nothing here
        }
    }
}
