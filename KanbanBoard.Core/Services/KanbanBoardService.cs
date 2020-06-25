using System;
using System.Collections.Generic;
using KanbanBoard.Core.Command;
using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Domain.Exceptions;
using KanbanBoard.Core.Infrastucture;

namespace KanbanBoard.Core.Services
{
    public class KanbanBoardService
    {
        private readonly IPostItRepository _postItRepository;
        private readonly IClockService _clockService;
        private readonly IUserRepository _userRepository;

        public KanbanBoardService(
            IPostItRepository postItRepository,
            IClockService clockService,
            IUserRepository userRepository)
        {
            _postItRepository = postItRepository;
            _clockService = clockService;
            _userRepository = userRepository;
        }

        public List<PostIt> GetAllPostIts()
        {
            return _postItRepository.GetAll();
        }

        public void AddPostIt(AddPostItCommand postItCommand)
        {
            var postIt = new PostIt()
            {
                Title = postItCommand.Title,
                Description = postItCommand.Description,
                Status = PostItStatus.TODO,
                CreatedAt = _clockService.GetNow()
            };

            _postItRepository.Add(postIt);
        }

        public PostIt GetPostIt(long id)
        {
            return _postItRepository.GetById(id);
        }

        public void UpdatePostIt(UpdatePostItCommand postItCommand)
        {
            PostIt postId = _postItRepository.GetById(postItCommand.Id);
            postId.Title = postItCommand.Title;
            postId.Description = postItCommand.Description;

            _postItRepository.Update(postId);
        }

        public User GetUser(string userName, string password)
        {
            return _userRepository.GetByUserNamePassword(userName, password);
        }

        public void UpdatePostItStatus(long id, PostItStatus postItStatus)
        {
            var postIt = _postItRepository.GetById(id);

            if (postIt == null)
                throw new ArgumentOutOfRangeException(id.ToString());

            if (postIt.Status == PostItStatus.TODO && postItStatus == PostItStatus.INPROGRESS)
            {
                postIt.StartedAt = _clockService.GetNow();
                postIt.Status = postItStatus;
                _postItRepository.Update(postIt);
            }
            else if (postIt.Status == PostItStatus.INPROGRESS && postItStatus == PostItStatus.DONE)
            {
                postIt.ClosedAt = _clockService.GetNow();
                postIt.Status = postItStatus;
                _postItRepository.Update(postIt);
            }
            else
                throw new InvalideTransitionForPostItException(id, postIt.Status, postItStatus);
        }
    }
}
