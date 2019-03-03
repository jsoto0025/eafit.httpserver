using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HttpServer.XUnit.Test.RequestParser
{
    public class RequestParserTest
    {
        [Fact]
        public void MyTest()
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
            Assert.Equal(request.Version, "1.1");
        }
    }
}
