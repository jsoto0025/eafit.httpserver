using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing.Processors
{
    public class DefaultResponseProcessor : IProcessor
    {
        public void ProcessRequest(IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing)
        {
            Console.WriteLine("Request as default processor");

            next(request);
        }

        public void ProcessResponse(IHttpResponse response)
        {
            Console.WriteLine("Reponse at default processor");

            response.Protocol = Protocol.HTTP;
            response.Version = "1.1";
            response.StatusCode = "200";
            response.StatusDescription = "OK";

            var headers = new List<HttpHeader>()
            {
                new HttpHeader("Date", DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffff")),
                new HttpHeader("Server", Environment.MachineName),
                new HttpHeader("Content-Type", "text/html")
            };

            response.Headers = headers;
            response.Body = "<h1>200 OK </h1>";
        }
    }
}
