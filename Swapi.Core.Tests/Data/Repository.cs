using Microsoft.Extensions.Logging;
using Moq;
using Swapi.Core.Data;
using Swapi.Core.Entities;
using Swapi.Core.Interfaces;

namespace Swapi.Core.Tests.Data
{
    public class Repository
    {
        [Fact]
        public async void RepositoryT_GetEntityAsync_Returns_TaskT()
        {
            // Arrange
            var expected = new Film() { Title = "TEST" };
            var loggerMock = Mock.Of<ILogger<Application>>();
            var dataServiceMock = new Mock<IDataService<Film>>();
            dataServiceMock
                .Setup(s => s.GetDataResultAsync())
                .Returns(Task.FromResult(expected));

            var repository = new Repository<Film>(loggerMock, dataServiceMock.Object);

            // Act
            var actual = await repository.GetEntityAsync();

            // Assert
            Assert.Equivalent(expected, actual);
        }
    }
}
