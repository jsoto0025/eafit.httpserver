﻿using System;
using System.Collections.Generic;
using System.Text;
using HttpServer.RequestParser;

namespace HttpServer.Processing
{
    public class ValidationProcessor : IProcessor
    {
        public void ProcessRequest(IHttpRequest httpMessage, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing)
        {
            Console.WriteLine("Processor 1");

            next(httpMessage);
        }

        public void ProcessResponse(IHttpResponse httpMessage)
        {
            Console.WriteLine("Reponse at processor 1");

            // Litterally do nothing here
        }
    }
}
