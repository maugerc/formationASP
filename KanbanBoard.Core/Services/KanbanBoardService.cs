using System.Collections.Generic;
using KanbanBoard.Core.Command;
using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Infrastucture;

namespace KanbanBoard.Core.Services
{
    public class KanbanBoardService
    {
        private readonly IPostItRepository _postItRepository;
        private readonly IClockService _clockService;

        public KanbanBoardService(IPostItRepository postItRepository, IClockService clockService)
        {
            _postItRepository = postItRepository;
            _clockService = clockService;
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
    }
}
