using System.Collections.Generic;
using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Infrastucture;
using KanbanBoard.Core.Services;
using Moq;
using NFluent;
using Xunit;

namespace KanbanBoard.Core.Tests
{
    public class KanbanBoardServiceTests
    {
        [Fact]
        public void WhenGetAllPostItsThenGetPostItsList()
        {
            // Arrange
            var repository = new Mock<IPostItRepository>();
            var userRepository = new Mock<IUserRepository>();
            var utcClockService = new Mock<IClockService>();
            var postIts = new List<PostIt>() { new PostIt() { Title = "Post It 1" } };

            repository.Setup(r => r.GetAll())
                .Returns(postIts);
            var service = new KanbanBoardService(repository.Object, utcClockService.Object, userRepository.Object);

            // Act
            var result = service.GetAllPostIts();

            // Assert
            Check.That(result).ContainsExactly(postIts);
        }
    }
}
