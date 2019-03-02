using HttpServer.RequestParser;
using System;

namespace HttpServer.Processing
{
    public interface IProcessor
    {
        void ProcessRequest(IHttpMessage httpMessage, Action<IHttpMessage> next, Action<IHttpMessage> stopProcessing);
        void ProcessResponse(IHttpMessage httpMessage);
    }
}