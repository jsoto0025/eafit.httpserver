using HttpServer.RequestParser;
using System;

namespace HttpServer.Processing
{
    /// <summary>
    /// Interface con la definición de los métodos que se deben de finir por cadad procesador.
    /// </summary>
    public interface IProcessor
    {
        /// <summary>
        /// Método para procesar el objeto request
        /// </summary>
        /// <param name="request">Objeto con el mensaje enviado por el cliente</param>
        /// <param name="next">Callback que indica, cual es el siguiente processor a ejecutar si la ejecucón del método actual se ejecuta correctamente</param>
        /// <param name="stopProcessing">Callback que se ejecuta si ocurrio algún problema con la ejecución del método actual</param>
        void ProcessRequest(IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing);
        /// <summary>
        /// Método para generar el response
        /// </summary>
        /// <param name="response"></param>
        void ProcessResponse(IHttpResponse response);
    }
}