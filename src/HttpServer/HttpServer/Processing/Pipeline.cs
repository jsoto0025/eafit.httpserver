using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing
{
    public class Pipeline
    {
        /// <summary>
        /// Lista de procesadores pendientes por ejecutar
        /// </summary>
        private Queue<IProcessor> PendingProcessors { get; set; }

        /// <summary>
        /// Lista de procesadores ya ejecutados
        /// </summary>
        private Stack<IProcessor> DoneProcessor { get; set; }

        /// <summary>
        /// Almacena una referencia a la respuesta
        /// </summary>
        public IHttpResponse Response { get; private set; }

        /// <summary>
        /// Constructor que inicializa la lista de procesadores
        /// </summary>
        public Pipeline()
        {
            PendingProcessors = new Queue<IProcessor>();
            DoneProcessor = new Stack<IProcessor>();
        }

        public void AddProcessor(IProcessor processor)
        {
            PendingProcessors.Enqueue(processor);
        }

        /// <summary>
        /// Ejecuta la lista de procesadores
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Devuelve el obejto Response que se retorna como respuesta al cliente.</returns>
        public IHttpResponse Run(IHttpRequest request)
        {
            ProcessRequest(request);

            return Response;
        }

        /// <summary>
        /// Activa el siquiente procesador a ser ejecutado
        /// </summary>
        /// <param name="request"></param>
        private void GoToNextProcessor(IHttpRequest request)
        {
            if (PendingProcessors.Count > 0)
            {
                ProcessRequest(request);
            }
            else
            {
                StopProcessing(new Response());
            }
        }

        /// <summary>
        /// Ejecuta el procesador actual
        /// </summary>
        /// <param name="request"></param>
        private void ProcessRequest(IHttpRequest request)
        {
            var processor = PendingProcessors.Dequeue();

            DoneProcessor.Push(processor);

            processor.ProcessRequest(request, GoToNextProcessor, StopProcessing);
        }

        /// <summary>
        /// Detiene la ejecucón del pipeline
        /// </summary>
        /// <param name="response"></param>
        private void StopProcessing(IHttpResponse response)
        {
            Response = response;

            while (DoneProcessor.Count > 0)
            {
                DoneProcessor.Pop().ProcessResponse(response);
            }
        }
    }
}
