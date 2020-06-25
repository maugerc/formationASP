using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Domain.Exceptions;
using KanbanBoard.Core.Infrastucture;
using KanbanBoard.Core.Services;
using Moq;
using NFluent;
using Xunit;

namespace KanbanBoard.Core.Tests.Services
{
    public class KanbanBoardServiceShould
    {
        private Mock<IPostItRepository> _postItRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<IClockService> _clockService;
        private KanbanBoardService _service;

        public KanbanBoardServiceShould()
        {
            _postItRepository = new Mock<IPostItRepository>();
            _userRepository = new Mock<IUserRepository>();
            _clockService = new Mock<IClockService>();

            _service = new KanbanBoardService(
                _postItRepository.Object,
                _clockService.Object,
                _userRepository.Object);
        }

        // Given Then When
        [Theory]
        [InlineData(PostItStatus.TODO, PostItStatus.INPROGRESS)]
        [InlineData(PostItStatus.INPROGRESS, PostItStatus.TODO)]
        public void AcceptUpdatePostItStatusForAllowedTransitions(PostItStatus sourceStatus, PostItStatus destStatus)
        {
            // Arrange
            var postIt = new PostIt() { Status = sourceStatus };

            _postItRepository
                .Setup(p => p.GetById(It.IsAny<long>()))
                .Returns(postIt);

            // Act
            _service.UpdatePostItStatus(postIt.Id, destStatus);

            // Assert
            _postItRepository.Verify(r => r.Update(It.Is<PostIt>(p => p.Status == destStatus)), Times.Once);
        }

        [Theory]
        [InlineData(PostItStatus.TODO, PostItStatus.DONE)]
        [InlineData(PostItStatus.INPROGRESS, PostItStatus.TODO)]
        [InlineData(PostItStatus.DONE, PostItStatus.TODO)]
        [InlineData(PostItStatus.DONE, PostItStatus.INPROGRESS)]
        public void RaiseAnExceptionWhenUpdatePostItStatusForForbidenTransitions(PostItStatus sourceStatus, PostItStatus destStatus)
        {
            // Arrange
            var postIt = new PostIt() { Id = 1, Status = sourceStatus };

            _postItRepository
                .Setup(p => p.GetById(It.IsAny<long>()))
                .Returns(postIt);

            // Act
            // Assert
            Check
                .ThatCode(() => _service.UpdatePostItStatus(postIt.Id, destStatus))
                .Throws<InvalideTransitionForPostItException>();
        }
    }
}
