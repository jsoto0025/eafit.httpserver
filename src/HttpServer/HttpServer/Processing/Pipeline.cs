using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing
{
    public class Pipeline
    {
        private List<IProcessor> Processors { get; set; }
        private IProcessor[] ProcessorsCache { get; set; }
        private int currentProcessorIndex { get; set; }
        public IHttpResponse Response { get; private set; }

        public Pipeline()
        {
            Processors = new List<IProcessor>();
        }

        public void AddProcessor(IProcessor processor)
        {
            Processors.Add(processor);
        }

        private void CacheProcessorsArray()
        {
            ProcessorsCache = Processors.ToArray();
        }

        public IHttpResponse Run(IHttpRequest request)
        {
            currentProcessorIndex = 0;
            CacheProcessorsArray();

            // We get the first processor to start the processing
            ProcessRequest(request, currentProcessorIndex: 0);

            return Response;
        }

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

        private void ProcessRequest(IHttpRequest request, int currentProcessorIndex)
        {
            var processor = ProcessorsCache[currentProcessorIndex];

            processor.ProcessRequest(request, GoToNextProcessor, StopProcessing);
        }

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
