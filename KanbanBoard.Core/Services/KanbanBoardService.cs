using System.Collections.Generic;
using KanbanBoard.Core.Domain;
using KanbanBoard.Core.Infrastucture;

namespace KanbanBoard.Core.Services
{
    public class KanbanBoardService
    {
        private readonly IPostItRepository _postItRepository;

        public KanbanBoardService(IPostItRepository postItRepository)
        {
            _postItRepository = postItRepository;
        }

        public List<PostIt> GetAllPostIts()
        {
            return _postItRepository.GetAll();
        }
    }
}
