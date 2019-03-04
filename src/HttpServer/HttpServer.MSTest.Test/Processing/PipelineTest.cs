using HttpServer.Processing;
using HttpServer.RequestParser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.MSTest.Test.Processing
{
    [TestClass]
    public class PipelineTest
    {
        [TestMethod]
        public void VerificarQueTodosLosProcesadoresSeanEjecutadosTest ()
        {
            //Arrange
            var action = new Mock<Action<IHttpRequest>>();

            var pipeline = new Pipeline();

            var requestMockConfigure = new Mock<IHttpRequest>();

            var processorMock1 = new Mock<IProcessor>();
            
            //Act

            processorMock1.Setup(mock => mock.ProcessRequest(requestMockConfigure.Object, It.IsAny<Action<IHttpRequest>>(), It.IsAny<Action<IHttpResponse>>()))
                .Callback((IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing) => next(request));


            var processorMock2 = new Mock<IProcessor>();

            processorMock2.Setup(x => x.ProcessRequest(requestMockConfigure.Object, It.IsAny<Action<IHttpRequest>>(), It.IsAny<Action<IHttpResponse>>()))
                .Callback((IHttpRequest request, Action<IHttpRequest> next, Action<IHttpResponse> stopProcessing) => next(request));
            
            pipeline.AddProcessor(processorMock1.Object);
            pipeline.AddProcessor(processorMock2.Object);

            pipeline.Run(requestMockConfigure.Object);

            //Assert
            processorMock1.Verify(x => x.ProcessRequest(requestMockConfigure.Object, It.IsAny<Action<IHttpRequest>>(), It.IsAny<Action<IHttpResponse>>()), Times.Once());
            processorMock2.Verify(x => x.ProcessRequest(requestMockConfigure.Object, It.IsAny<Action<IHttpRequest>>(), It.IsAny<Action<IHttpResponse>>()), Times.Once());
        }
    }
}
