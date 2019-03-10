using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using HttpServer.Logging;
using HttpServer.RequestParser;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HttpServer.Processing.Processors
{
    /// <summary>
    /// Procesador que se encarga de ejecutar las tareas de loging
    /// </summary>
    public class LoggerProcessor : IProcessor
    {
        /// <summary>
        /// Escribe en el log el request actual.
        /// </summary>
        /// <param name="request">Objeto request</param>
        /// <param name="next">Callback que indica al pipeline que debe de seguir con el siguiente procesador </param>
        /// <param name="stopProcessing"></param>
        public void ProcessRequest(IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new StringEnumConverter());
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(HttpServerResources.LoggerFileName, append: true))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, request);
                sw.WriteLine();
                sw.WriteLine();
            }

            TraceLogger.ConsoleLog(HttpServerResources.LoggerProcessRequestStatus);

            next(request);
        }

        /// <summary>
        /// Escribe en la consola el estado del procesador de log
        /// </summary>
        /// <param name="response"></param>
        public void ProcessResponse(IHttpResponse response)
        {
            TraceLogger.ConsoleLog(HttpServerResources.LoggerProcessResponseStatus);
        }
    }
}
