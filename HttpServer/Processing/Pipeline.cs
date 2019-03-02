using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing
{
    public class Pipeline
    {
        public List<IProcessor> Processors { get; set; }
        private IProcessor[] ProcessorsCache { get; set; }
        private int currentProcessorIndex { get; set; }

        public Pipeline()
        {
            Processors = new List<IProcessor>();
        }

        private void CacheProcessorsArray()
        {
            ProcessorsCache = Processors.ToArray();
        }

        internal void Start(IHttpMessage request)
        {
            currentProcessorIndex = 0;
            CacheProcessorsArray();

            // We get the first processor to start the processing
            ProcessRequest(request, currentProcessorIndex: 0);
        }

        private void GoToNextProcessor(IHttpMessage request)
        {
            currentProcessorIndex++;

            if (currentProcessorIndex < ProcessorsCache.Length)
            {
                ProcessRequest(request, currentProcessorIndex);
            }
            else
            {
                //TODO: Build response here
                StopProcessing(request);
            }
        }

        private void ProcessRequest(IHttpMessage request, int currentProcessorIndex)
        {
            var processor = ProcessorsCache[currentProcessorIndex];

            processor.ProcessRequest(request, GoToNextProcessor, StopProcessing);
        }

        private void StopProcessing(IHttpMessage response)
        {
            for (int i = ProcessorsCache.Length - 1; i >= 0; i--)
            {
                ProcessorsCache[i].ProcessResponse(response);
            }
        }
    }
}
