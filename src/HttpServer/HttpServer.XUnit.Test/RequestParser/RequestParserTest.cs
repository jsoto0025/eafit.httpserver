using HttpServer.RequestParser;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace HttpServer.XUnit.Test.RequestParser
{
    public class RequestParserTest
    {
        [Fact]
        public void GetRequestParsingsTest()
        {
            var httpString = @"GET http://www.google.com/ HTTP/1.1
Host: www.google.com
Connection: keep-alive
Cache-Control: no-cache
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.119 Safari/537.36
Postman-Token: 61619fa3-45e0-0bf6-6662-8b5aa9765426
Accept: */*
Accept-Encoding: gzip, deflate
Accept-Language: es,en-US;q=0.9,en;q=0.8
";


            var parser = new HttpServer.RequestParser.RequestParser();

            var request = parser.Parse(httpString);

            Assert.NotNull(request);
            Assert.Equal(Method.GET, request.Method);
            Assert.Equal("http://www.google.com/", request.Host);
            Assert.Equal( "1.1", request.Version);
            Assert.Equal( Protocol.HTTP, request.Protocol);
            Assert.Null(request.Body);
          

            var headers = new List<HttpHeader>();
            headers.Add(new HttpHeader("Host", "www.google.com"));
            headers.Add(new HttpHeader("Connection", "keep-alive"));
            headers.Add(new HttpHeader("Cache-Control", "no-cache"));
            headers.Add(new HttpHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.119 Safari/537.36"));
            headers.Add(new HttpHeader("Postman-Token", "61619fa3-45e0-0bf6-6662-8b5aa9765426"));
            headers.Add(new HttpHeader("Accept", "*/*"));
            headers.Add(new HttpHeader("Accept-Encoding", "gzip, deflate"));
            headers.Add(new HttpHeader("Accept-Language", "es,en-US;q=0.9,en;q=0.8"));

            request.Headers.Should().BeEquivalentTo(headers);
        }

        [Fact]
        public void PostRequestParsingsTest()
        {
            var httpString = @"POST http://www.google.com/ HTTP/1.1
Host: www.google.com
Connection: keep-alive
Content-Length: 21
User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.119 Safari/537.36
Cache-Control: no-cache
Origin: null
Postman-Token: 78e3b2fa-9e12-50b5-4b75-0771ca8d7778
Content-Type: application/json
Accept: */*
Accept-Encoding: gzip, deflate, br
Accept-Language: es,en-US;q=0.9,en;q=0.8
Cookie: 1P_JAR=2019-03-03-14; NID=162=QiXh8uhwzXBbOMtFsNpBE1V-iofreZh6kmMyCEDWmR5u2rm-oT2_0spQAvRZeAJjEPsQeJbmj3q6aGvJTnTUIpCBbivmM89P9rvQdCTfK6gypyAZ_Wfykxt6P3Gkfnh3W3yxKl0KdEE-qgg5OAThlibN__RI6ZLbZOcajmgrr1Y

{" +
   "\"Name\": \"Test\"" +
"}";

            var expectedBody = "{" +
   "\"Name\": \"Test\"" +
"}";


            var parser = new HttpServer.RequestParser.RequestParser();

            var request = parser.Parse(httpString);

            Assert.NotNull(request);
            Assert.Equal(Method.POST, request.Method);
            Assert.Equal("http://www.google.com/", request.Host);
            Assert.Equal("1.1", request.Version);
            Assert.Equal(Protocol.HTTP, request.Protocol);
            Assert.Equal(request.Body, expectedBody);


            var headers = new List<HttpHeader>();
            headers.Add(new HttpHeader("Host", "www.google.com"));
            headers.Add(new HttpHeader("Connection", "keep-alive"));
            headers.Add(new HttpHeader("Content-Length", "21"));
            headers.Add(new HttpHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.119 Safari/537.36"));
            headers.Add(new HttpHeader("Cache-Control", "no-cache"));
            headers.Add(new HttpHeader("Origin", "null"));
            headers.Add(new HttpHeader("Postman-Token", "78e3b2fa-9e12-50b5-4b75-0771ca8d7778"));
            headers.Add(new HttpHeader("Content-Type", "application/json"));
            headers.Add(new HttpHeader("Accept", "*/*"));
            headers.Add(new HttpHeader("Accept-Encoding", "gzip, deflate, br"));
            headers.Add(new HttpHeader("Accept-Language", "es,en-US;q=0.9,en;q=0.8"));
            headers.Add(new HttpHeader("Cookie", "1P_JAR=2019-03-03-14; NID=162=QiXh8uhwzXBbOMtFsNpBE1V-iofreZh6kmMyCEDWmR5u2rm-oT2_0spQAvRZeAJjEPsQeJbmj3q6aGvJTnTUIpCBbivmM89P9rvQdCTfK6gypyAZ_Wfykxt6P3Gkfnh3W3yxKl0KdEE-qgg5OAThlibN__RI6ZLbZOcajmgrr1Y"));

            request.Headers.Should().BeEquivalentTo(headers);
        }
    


        [Fact]
        public void GetResponseSerializationTest()
        {
            var httpString = @"HTTP/1.1 200 OK
Date: Sun, 03 Mar 2019 00:35:42 GMT
Server: Prueba
Content-Type: text/html

<h1>200 OK </h1>";

            var response = new Response();
            response.Protocol = Protocol.HTTP;
            response.Version = "1.1";
            response.CodigoEstado = "200";
            response.DescripcionEstado = "OK";
            var headers = new List<HttpHeader>();
            headers.Add(new HttpHeader("Date", "Sun, 03 Mar 2019 00:35:42 GMT"));
            headers.Add(new HttpHeader("Server", "Prueba"));
            headers.Add(new HttpHeader("Content-Type", "text/html"));

            response.Headers = headers;
            response.Body = "<h1>200 OK </h1>";

            var parser = new HttpServer.RequestParser.RequestParser();

            var request = parser.Serialize(response);

            Assert.NotNull(request);
            Assert.Equal(request.ToString(), httpString); //Validar que el string que devuelve serializable se igual al de la prueba
      
        }
    }
}
