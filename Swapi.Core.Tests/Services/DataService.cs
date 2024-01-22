using Microsoft.Extensions.Logging;
using Moq;
using Swapi.Core.Entities;
using Swapi.Core.Interfaces;
using Swapi.Core.Services;

namespace Swapi.Core.Tests.Services
{
    public class DataService
    {
        [Fact]
        public async void DataServiceT_GetDataResultAsync_Returns_TaskT()
        {
            // Arrange
            var expected = new Film() { Title = "TEST" };
            var loggerMock = Mock.Of<ILogger<Application>>();
            var fileServiceMock = Mock.Of<IFileService>();
            var httpServiceMock = new Mock<IHttpService<Film>>();
            httpServiceMock
                .Setup(s => s.HttpGetAsync())
                .Returns(Task.FromResult(expected)!);
            var httpClientFactoryMock = Mock.Of<IHttpClientFactory>();

            var dataService = new DataService<Film>(loggerMock, httpServiceMock.Object, fileServiceMock, httpClientFactoryMock);

            // Act
            var actual = await dataService.GetDataResultAsync();

            // Assert
            Assert.Equivalent(expected, actual);
        }
    }
}
