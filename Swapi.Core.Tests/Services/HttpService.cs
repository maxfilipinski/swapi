using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Swapi.Core.Entities;
using Swapi.Core.Services;
using System.Text.Json;

namespace Swapi.Core.Tests.Services
{
    public class HttpService
    {
        [Fact]
        public async void HttpServiceT_HttpGetAsync_Returns_TaskT()
        {
            // Arrange
            var expected = new Film() { Title = "TEST" };
            var loggerMock = Mock.Of<ILogger<Application>>();
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(expected))
                });

            var httpService = new HttpService<Film>(loggerMock, new HttpClient(httpMessageHandlerMock.Object));

            // Act
            var actual = await httpService.HttpGetAsync();

            // Assert
            Assert.Equivalent(expected, actual);
        }
    }
}
