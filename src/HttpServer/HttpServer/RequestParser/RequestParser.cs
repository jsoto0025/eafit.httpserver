﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HttpServer.RequestParser
{
    public class RequestParser
    {
        public IHttpRequest Parse(string httpString)
        {
            var lines = httpString.Split('\n');

            var request = new Request();

            var requestLine = lines[0].Split(' ');
            request.Method = ParseMethod(requestLine[0]);

            request.Host = requestLine[1];

            var protocolFragments = requestLine[2].Split('/');

            request.Protocol = Protocol.HTTP;
            request.Version = protocolFragments[1].TrimEnd();

            request.Headers = new List<HttpHeader>();

            var headersEndPosition = 0;

            // Parse headers
            string[] headerSegments = null;
            for (int i = 1; i < lines.Length - 1; i++)
            {
                if (lines[i] == "\r")
                {
                    headersEndPosition = i;
                    break;
                }

                headerSegments = lines[i].Split(':');

                request.Headers.Add(new HttpHeader(headerSegments[0], headerSegments[1].Trim()));
            }

            if (headersEndPosition > 0 && headersEndPosition < lines.Length)
            {
                var stringBuilder = new StringBuilder();

                for (int i = headersEndPosition + 1; i < lines.Length; i++)
                {
                    stringBuilder.Append(lines[i]);
                }

                request.Body = stringBuilder.ToString();
            }

            return request;
        }

        private Method ParseMethod(string requestLine)
        {
            switch (requestLine.ToUpper())
            {
                case "GET":
                    return Method.GET;
                case "POST":
                    return Method.POST;
                case "HEAD":
                    return Method.HEAD;
                case "PUT":
                    return Method.PUT;
                case "DELETE":
                    return Method.DELETE;
                default:
                    return Method.GET;
            }
        }
    }
}
