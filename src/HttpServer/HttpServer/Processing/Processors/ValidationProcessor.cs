using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpServer.Logging;
using HttpServer.RequestParser;

namespace HttpServer.Processing.Processors
{
    public class ValidationProcessor : IProcessor
    {
        public void ProcessRequest(IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing)
        {
            TraceLogger.ConsoleLog(HttpServerResources.ValidationProcessorTrackingMessage);

            if (!request.Method.HasValue)
            {
                stopProcessing(BuildErrorResponse());
            }
            else
            {
                next(request);
            }
        }

        public void ProcessResponse(IHttpResponse response)
        {
            TraceLogger.ConsoleLog(HttpServerResources.ValidationProcessorTrackingMessage);
        }

        private IHttpResponse BuildErrorResponse()
        {
            var response = new Response();

            response.Protocol = Protocol.HTTP;
            response.Version = HttpServerResources.HttpVersion;
            response.StatusCode = HttpServerResources.StatusCode400;
            response.StatusDescription = HttpServerResources.StatusCode400Message;

            var headers = new List<HttpHeader>();
            headers.Add(new HttpHeader(HttpServerResources.HeaderGeneralDateName, DateTime.UtcNow.ToString(HttpServerResources.HeaderGeneralDateFormat)));
            headers.Add(new HttpHeader(HttpServerResources.HeaderGeneralServerName, Environment.MachineName));
            headers.Add(new HttpHeader(HttpServerResources.HeaderContentType, HttpServerResources.HeaderContentTypeHtml));

            response.Headers = headers;
            response.Body = HttpServerResources.ValidationProcessorResponseBody;

            return response;
        }
    }
}
