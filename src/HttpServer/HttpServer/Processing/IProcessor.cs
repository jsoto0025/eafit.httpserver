using HttpServer.RequestParser;
using System;

namespace HttpServer.Processing
{
    public interface IProcessor
    {
        void ProcessRequest(IHttpRequest httpMessage, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing);
        void ProcessResponse(IHttpResponse httpMessage);
    }
}