using HttpServer.Processing;
using HttpServer.RequestParser;
using Moq;
using System;
using Xunit;

namespace HttpServer.XUnit.Test.Processing
{
    public class PipelineTest
    {
        [Fact]
        public void VerifyThatAllTheProcessorsGetCalledTest()
        {
            var action = new Mock<Action<IHttpRequest>>();

            var pipeline = new Pipeline();

            var requestMockConfigure = new Mock<IHttpRequest>();

            var processorMock1 = new Mock<IProcessor>();


            // Configure what happends went the ProcessRequest gets called
            processorMock1.Setup(mock => mock.ProcessRequest(requestMockConfigure.Object, It.IsAny<Action<IHttpRequest>>(), It.IsAny<Action<IHttpResponse>>()))
                .Callback((IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing) => next(request));


            var processorMock2 = new Mock<IProcessor>();
            processorMock2.Setup(x => x.ProcessRequest(requestMockConfigure.Object, It.IsAny<Action<IHttpRequest>>(), It.IsAny<Action<IHttpResponse>>()))
                .Callback((IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing) => next(request));


            // Configuring processors
            pipeline.AddProcessor(processorMock1.Object);
            pipeline.AddProcessor(processorMock2.Object);

            pipeline.Run(requestMockConfigure.Object);

            // Verify that the request gets processed in all configured processors
            processorMock1.Verify(x => x.ProcessRequest(requestMockConfigure.Object, It.IsAny<Action<IHttpRequest>>(), It.IsAny<Action<IHttpResponse>>()), Times.Once());
            processorMock2.Verify(x => x.ProcessRequest(requestMockConfigure.Object, It.IsAny<Action<IHttpRequest>>(), It.IsAny<Action<IHttpResponse>>()), Times.Once());
        }
    }
}
