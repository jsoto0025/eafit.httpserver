using HttpServer.RequestParser;
using System;

namespace HttpServer.Processing
{
    public interface IProcessor
    {
        void ProcessRequest(IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing);
        void ProcessResponse(IHttpResponse response);
    }
}