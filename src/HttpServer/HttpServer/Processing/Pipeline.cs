using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing
{
    public class Pipeline
    {
        /// <summary>
        /// Lista de procesadores disponibles
        /// </summary>
        private List<IProcessor> Processors { get; set; }

        private IProcessor[] ProcessorsCache { get; set; }
        /// <summary>
        /// Inidice del procesador actual
        /// </summary>
        private int currentProcessorIndex { get; set; }
        public IHttpResponse Response { get; private set; }

        /// <summary>
        /// Constructor que inicializa la lista de procesadores
        /// </summary>
        public Pipeline()
        {
            Processors = new List<IProcessor>();
        }

        public void AddProcessor(IProcessor processor)
        {
            Processors.Add(processor);
        }

        /// <summary>
        /// Combierte el List de Procesadores en Array
        /// </summary>
        private void CacheProcessorsArray()
        {
            ProcessorsCache = Processors.ToArray();
        }

        /// <summary>
        /// Ejecuta la lista de procesadores
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Devuelve el obejto Response que se retorna como respuesta al cliente.</returns>
        public IHttpResponse Run(IHttpRequest request)
        {
            currentProcessorIndex = 0;
            CacheProcessorsArray();
            
            ProcessRequest(request, currentProcessorIndex: 0);

            return Response;
        }

        /// <summary>
        /// Activa el siquiente procesador a ser ejecutado
        /// </summary>
        /// <param name="request"></param>
        private void GoToNextProcessor(IHttpRequest request)
        {
            currentProcessorIndex++;

            if (currentProcessorIndex < ProcessorsCache.Length)
            {
                ProcessRequest(request, currentProcessorIndex);
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
        /// <param name="currentProcessorIndex"></param>
        private void ProcessRequest(IHttpRequest request, int currentProcessorIndex)
        {
            var processor = ProcessorsCache[currentProcessorIndex];

            processor.ProcessRequest(request, GoToNextProcessor, StopProcessing);
        }

        /// <summary>
        /// Detiene la ejecucón del pipeline
        /// </summary>
        /// <param name="response"></param>
        private void StopProcessing(IHttpResponse response)
        {
            Response = response;

            for (int i = ProcessorsCache.Length - 1; i >= 0; i--)
            {
                ProcessorsCache[i].ProcessResponse(response);
            }
        }
    }
}
