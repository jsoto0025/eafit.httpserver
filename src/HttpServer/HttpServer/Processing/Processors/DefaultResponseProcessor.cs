﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using HttpServer.Logging;
using HttpServer.RequestParser;

namespace HttpServer.Processing.Processors
{
    /// <summary>
    /// Interface para definir los métodos disponibles para el pipeline
    /// </summary>
    public class DefaultResponseProcessor : IProcessor
    {
        /// <summary>
        /// Método para procesar el objeto request
        /// </summary>
        /// <param name="request">Objeto request</param>
        /// <param name="next">Callback que indica al pipeline que debe de seguir con el siguiente procesador </param>
        /// <param name="stopProcessing">Callback que se ejecuta cuando ocurrio un error</param>
        public void ProcessRequest(IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing)
        {
            TraceLogger.ConsoleLog(HttpServerResources.DefaultProcessorRequestStatus);

            next(request);
        }

        public void ProcessResponse(IHttpResponse response)
        {
            TraceLogger.ConsoleLog(HttpServerResources.DefaultProcessorTrackingMessage);

            response.Protocol = Protocol.HTTP;
            response.Version = HttpServerResources.HttpVersion;
            response.StatusCode = HttpServerResources.StatusCode200;
            response.StatusDescription = HttpServerResources.StatusCode200Message;
            var headers = new List<HttpHeader>();
            headers.Add(new HttpHeader(HttpServerResources.HeaderGeneralDateName, DateTime.UtcNow.ToString(HttpServerResources.HeaderGeneralDateFormat)));
            headers.Add(new HttpHeader(HttpServerResources.HeaderGeneralServerName, Environment.MachineName));
            headers.Add(new HttpHeader(HttpServerResources.HeaderContentType, HttpServerResources.HeaderContentTypeHtml));

            response.Headers = headers;
            response.Body = HttpServerResources.DefaultProcessorResponseBody;
        }
    }
}
